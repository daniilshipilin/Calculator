@echo off

del /S /Q .\bin\Release\publish >nul 2>&1
rmdir /S /Q .\bin\Release\publish >nul 2>&1

dotnet publish -c Release --no-self-contained -o .\bin\Release\publish
pause
