ScriptDir="$(cd "$(dirname "${BASH_SOURCE[0]}")" >/dev/null 2>&1 && pwd)";
OutputDir="/out";

export TestRunName="$(date '+%Y-%m-%d_%H-%m-%S')";
export TestResultsDir="$ScriptDir/Z34 Test Results";

TestRunResultsDir="$TestResultsDir/$TestRunName";

dotnet test \
    --filter "TestCategory!=Demo" \
    --logger "console;verbosity=minimal" \
    --logger "trx" \
    --logger "html" \
    --results-directory "$TestRunResultsDir";

mv "$TestRunResultsDir" "$OutputDir";
echo "Test Results Moved To: $OutputDir/$TestRunName";
