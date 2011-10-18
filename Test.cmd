@echo off
setlocal

call "%~dp0Build.cmd" Debug

start "NUnit" "%~dp0packages\NUnit.2.5.10.11092\tools\nunit.exe" "%~dp0OATH.Net.sln"
