# Navigate to your Visual Studio 2022 solution folder
Set-Location "C:\Users\RonBandeira\Documents\Projects\Bandeira Clean Template"

# Define the search and replace text as variables
$searchText = "Bookify"
$replaceText = "Bandeira"

# Initialize counters for modified files, renamed files, and failures
$modifiedFiles = 0
$renamedFiles = 0
$failedFiles = 0

# Define the extensions to include
$extensions = @("*.cs", "*.json", "*.xml", "*.config", "*.sln", "*.DotSettings", "*.dcproj", "*.override", "*.csproj", "*.user")

# Replace text in files with specified extensions, excluding README.txt and ReplaceTextInFiles.ps1
Get-ChildItem -Include $extensions -Recurse | Where-Object { !$_.PSIsContainer -and $_.Name -notin @('README.txt', 'ReplaceTextInFiles.ps1') } | ForEach-Object {
    try {
        # Replace content in files
        $content = Get-Content $_.FullName
        $newContent = $content -replace $searchText, $replaceText
        if ($newContent -ne $content) {
            $newContent | Set-Content $_.FullName
            $modifiedFiles++
        }

        # Rename files
        $newName = $_.Name -replace $searchText, $replaceText
        if ($newName -ne $_.Name) {
            $newPath = Join-Path (Split-Path -Parent $_.FullName) $newName
            if (Test-Path $newPath) {
                Write-Host "File with the new name already exists, skipping: $newPath"
            } else {
                Rename-Item -Path $_.FullName -NewName $newName
                $renamedFiles++
            }
        }


    } catch {
        Write-Host "Skipped file due to error: $_"
        $failedFiles++
    }
}

# Output the number of modified, renamed, and failed files
Write-Host "Number of modified files: $modifiedFiles"
Write-Host "Number of renamed files: $renamedFiles"
Write-Host "Number of failed files: $failedFiles"
