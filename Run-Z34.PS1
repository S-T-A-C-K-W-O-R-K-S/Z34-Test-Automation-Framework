$ENV:TestRunName = Get-Date -Format "yyyy-MM-dd_HH-mm-ss"
$ENV:TestResultsDir = Join-Path -Path "$PSScriptRoot" -ChildPath "Z34 Test Results"

$TestRunResultsDir = Join-Path -Path "$ENV:TestResultsDir" -ChildPath "$ENV:TestRunName"

dotnet test `
    --filter "TestCategory!=Demo" `
    --logger "console;verbosity=minimal" `
    --logger "trx" `
    --logger "html" `
    --results-directory "$TestRunResultsDir" `
