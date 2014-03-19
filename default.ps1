# OATH.NET Psake build script

## Primary Build Tasks ##

Task Build      -Depend BuildSolution           -Description "Builds the project"
Task Test       -Depend Build, TestSolution     -Description "Runs all unit tests"
Task Package    -Depend Test, CreateNuPkg       -Description "Creates the NuGet package"
Task Clean      -Depend CleanSolution           -Description "Deletes all build artifacts"
Task Default    -Depend Test


## Build Process ##

Framework "4.0"

Properties {
    if (!$Configuration) { $Configuration = "Release" }

    $workingTree = Resolve-Path .
    $solution   = "$workingTree\OATH.Net.sln"
    $nuspec     = "$workingTree\OATH.Net.nuspec"

    $nunit = "$workingTree\packages\NUnit.Runners.2.6.3\tools\nunit-console.exe"
    $testAssembly = "$workingTree\OATH.Net.Test\bin\$Configuration\OATH.Net.Test.dll"

    $nuget = GetNuGetPath
}

Task RestoreNuGetPackages {
    Status "Restoring NuGet packages"
    Exec { & $nuget restore $solution -NonInteractive }
}

Task BuildSolution -Depend RestoreNuGetPackages {
    Exec { msbuild /target:build $solution /p:Configuration=$configuration }
}

Task TestSolution {
    Exec { & $nunit "$testAssembly" /framework=net-4.0 /nologo }
}

Task CleanSolution {
    Exec { msbuild /target:clean $solution /p:Configuration=$Configuration }
    del -ErrorAction Ignore *.nupkg
    del -ErrorAction Ignore TestResult.xml
}

Task CreateNuPkg {
    Exec { & $nuget pack $nuspec }
}


## Helpers ##

function GetNuGetPath {
    if (Get-Command "nuget" -ErrorAction SilentlyContinue) {
        $nuget = "nuget.exe"
    } else {
        $temp = [System.IO.Path]::GetTempPath()
        $nuget = "${temp}nuget.exe"
        if (!(Test-Path $nuget)) {
            Status "Downloading nuget.exe to $nuget"
            (New-Object System.Net.WebClient).DownloadFile("http://nuget.org/nuget.exe", $nuget)
        }
    }
    return $nuget
}

FormatTaskName {
    param($taskName)
    Write-Output ("=" * 72)
    Write-Output "Running task '$taskName'"
    Write-Output ("=" * 72)
}

function Status {
    param($text)
    Write-Output ("-" * 72)
    Write-Output " $text"
    Write-Output ("-" * 72)
}
