** renaming script
powershell -ExecutionPolicy Bypass -File .\ReplaceTextInFiles.ps1


Replace "C:\Path\To\Your\Solution\Folder", 'search_text', and 'replace_text' with your actual directory path and text strings.
Backup your project before running the script.

The -replace operator in PowerShell is case-sensitive.

** solution
Right click solution and Reload Project files. 

**
this file needed to be manually reconciled
bandeira-realm-export.json

** authentication keycloak
change realm and settings to new name of application
http://localhost:18080/