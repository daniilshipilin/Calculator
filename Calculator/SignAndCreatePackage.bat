@echo off

set "cert=%CodesignCertPath%"
set "timestamp=http://timestamp.digicert.com"

set "bin=.\bin"
set "src=%bin%\publish"

signtool.exe sign /fd sha256 /a /f "%cert%" "%src%\Calculator.exe"
signtool.exe timestamp /tr "%timestamp%" /td sha256 "%src%\Calculator.exe"

signtool.exe sign /fd sha256 /a /f "%cert%" "%src%\Calculator.dll"
signtool.exe timestamp /tr "%timestamp%" /td sha256 "%src%\Calculator.dll"

del /S /Q "%bin%\Calculator.zip" >nul 2>&1
7za.exe a -mx0 -tzip "%bin%\Calculator.zip" "%src%\*"
7za.exe h -scrcSHA256 "%bin%\Calculator.zip" > "%bin%\sha256.txt"

pause
