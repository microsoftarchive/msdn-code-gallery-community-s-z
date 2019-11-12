@echo off

set ADDIN_PATH=.\bin\Debug\SolidEdge.AddIn.EdgeBar.dll
set REGASM_X86="C:\Windows\Microsoft.NET\Framework\v4.0.30319\RegAsm.exe"
set REGASM_X64="C:\Windows\Microsoft.NET\Framework64\v4.0.30319\RegAsm.exe"

CLS

echo This batch file must be executed with administrator privileges!
echo. 

:menu
echo [Options]
echo 1 Register (Solid Edge x86)
echo 2 Unregister (Solid Edge x86)
echo 3 Register (Solid Edge x64)
echo 4 Unregister (Solid Edge x64)
echo 5 Quit

:choice
set /P C=Enter selection:
if "%C%"=="1" goto registerx86
if "%C%"=="2" goto unregisterx86
if "%C%"=="3" goto registerx64
if "%C%"=="4" goto unregisterx64
if "%C%"=="5" goto end
goto choice

:registerx86
set REGASM_PATH=%REGASM_X86%
goto register

:unregisterx86
set REGASM_PATH=%REGASM_X86%
goto unregister

:registerx64
set REGASM_PATH=%REGASM_X64%
goto register

:unregisterx64
set REGASM_PATH=%REGASM_X64%
goto unregister

:register
echo.
%REGASM_PATH% /codebase %ADDIN_PATH%
goto end

:unregister
echo.
%REGASM_PATH% /u %ADDIN_PATH%
goto end

:end
pause