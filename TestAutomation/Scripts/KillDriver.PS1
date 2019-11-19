$drivers = "chromedriver", "geckodriver", "msedgedriver"

ForEach ($driver in $drivers)
{
    Try {Stop-Process -Name $driver -ErrorAction Stop ; Write-Host "All Instances Stopped: $driver"}
    Catch [System.Management.Automation.RuntimeException] {"No Instances Found: " + $driver}
    Finally {$Error.Clear()}
}
