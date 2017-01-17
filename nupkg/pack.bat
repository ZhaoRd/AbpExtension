
@ECHO OFF
SET /P VERSION_SUFFIX=Please enter version-suffix (can be left empty): 

dotnet "pack" "..\src\AbpExtension\AbpExtension.Specifications" -c "Release" -o "." --version-suffix "%VERSION_SUFFIX%"

pause
