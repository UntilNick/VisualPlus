@echo off
Title VisualPlus Nuget Builder
color 17

echo This wizard will help you pack a nuget package.
echo.

echo Creating...
%nuget% pack nuget.nuspec
pause