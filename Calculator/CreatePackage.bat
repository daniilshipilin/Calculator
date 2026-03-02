@echo off

set "timestamp=http://timestamp.digicert.com"
set "publishDir=.\bin\publish"

del /S /Q %publishDir% >nul 2>&1
rmdir /S /Q %publishDir% >nul 2>&1
del /S /Q ".\bin\Calculator.zip" >nul 2>&1

dotnet publish -c Release -v m -o "%publishDir%"

if exist "%publishDir%" (
    signtool.exe sign /fd sha256 /a /f %CodesignCertPath% "%publishDir%\Calculator.exe"
    signtool.exe timestamp /tr "%timestamp%" /td sha256 "%publishDir%\Calculator.exe"
    signtool.exe sign /fd sha256 /a /f %CodesignCertPath% "%publishDir%\Calculator.dll"
    signtool.exe timestamp /tr "%timestamp%" /td sha256 "%publishDir%\Calculator.dll"
    7za.exe a -mx0 -tzip ".\bin\Calculator.zip" "%publishDir%\*" -xr!*.pdb
    7za.exe h -scrcSHA256 ".\bin\Calculator.zip" > ".\bin\sha256.txt"
)

pause
