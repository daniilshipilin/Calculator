@echo off

set "cert=C:\GitSources\CodeSign\Certificates\Illuminati_Software_Inc_Code_Sign.p12"
set "timestamp=http://timestamp.digicert.com"

set "bin=.\bin"
set "src=%bin%\Release\publish"

signtool.exe sign /fd sha256 /a /f "%cert%" "%src%\Calculator.exe"
signtool.exe timestamp /tr "%timestamp%" /td sha256 "%src%\Calculator.exe"

signtool.exe sign /fd sha256 /a /f "%cert%" "%src%\Calculator.dll"
signtool.exe timestamp /tr "%timestamp%" /td sha256 "%src%\Calculator.dll"

signtool.exe sign /fd sha256 /a /f "%cert%" "%src%\ApplicationUpdater.dll"
signtool.exe timestamp /tr "%timestamp%" /td sha256 "%src%\ApplicationUpdater.dll"

signtool.exe sign /fd sha256 /a /f "%cert%" "%src%\MathExpressionParser.dll"
signtool.exe timestamp /tr "%timestamp%" /td sha256 "%src%\MathExpressionParser.dll"

del /S /Q "%bin%\Calculator.zip" >nul 2>&1
7za.exe a -mx0 -tzip "%bin%\Calculator.zip" "%src%\*"
7za.exe h -scrcSHA256 "%bin%\Calculator.zip" > "%bin%\sha256.txt"

pause
