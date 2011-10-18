@echo off
setlocal

set CONFIGURATION=%~1

if "%CONFIGURATION%"=="" set CONFIGURATION=Debug

"%WINDIR%\Microsoft.NET\Framework\v4.0.30319\MSBuild.exe" ^
      %~dp0OATH.Net.sln ^
      /target:Clean;Build ^
      /property:Configuration=%CONFIGURATION%
