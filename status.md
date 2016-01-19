Status
======

```
  OK https://www.myget.org/F/dotnet-core/api/v3/flatcontainer/system.security.cryptography.primitives/4.0.0-rc2-23616/system.security.cryptography.primitives.4.0.0-rc2-23616.nupkg 2418ms
----------
System.ArgumentException: More than one runtime.json file has declared imports for 'ubuntu.14.04-x64'
Parameter name: runtimeName
   at Microsoft.Dnx.Tooling.RestoreCommand.FindRuntimeDependencies(String runtimeName, List`1 runtimeFiles, Dictionary`2 effectiveRuntimeSpecs, HashSet`1 allRuntimeNames, Func`2 circularImport)
   at Microsoft.Dnx.Tooling.RestoreCommand.FindRuntimeDependencies(String runtimeName, List`1 runtimeFiles, Dictionary`2 effectiveRuntimeSpecs, HashSet`1 allRuntimeNames)
   at Microsoft.Dnx.Tooling.RestoreCommand.<RestoreForProject>d__69.MoveNext()
--- End of stack trace from previous location where exception was thrown ---
   at System.Runtime.CompilerServices.TaskAwaiter.ThrowForNonSuccess(Task task)
   at System.Runtime.CompilerServices.TaskAwaiter.HandleNonSuccessAndDebuggerNotification(Task task)
   at System.Runtime.CompilerServices.TaskAwaiter`1.GetResult()
   at Microsoft.Dnx.Tooling.RestoreCommand.<>c__DisplayClass68_0.<<Execute>b__2>d.MoveNext()
--- End of stack trace from previous location where exception was thrown ---
   at System.Runtime.CompilerServices.TaskAwaiter.ThrowForNonSuccess(Task task)
   at System.Runtime.CompilerServices.TaskAwaiter.HandleNonSuccessAndDebuggerNotification(Task task)
   at System.Runtime.CompilerServices.TaskAwaiter.GetResult()
   at Microsoft.Dnx.Tooling.RestoreCommand.<Execute>d__68.MoveNext()
----------
Restore failed
More than one runtime.json file has declared imports for 'ubuntu.14.04-x64'
Parameter name: runtimeName

NuGet Config files used:
    /opt/dotkube/NuGet.Config

Feeds used:
    https://www.myget.org/F/aspnetcidev/api/v3/flatcontainer/
    https://api.nuget.org/v3-flatcontainer/
    https://www.myget.org/F/dotnet-core/api/v3/flatcontainer/
    https://www.myget.org/F/dotnet-cli/api/v3/flatcontainer/
    https://www.myget.org/F/coreclr-xunit/api/v2/
make: *** [build-api] Error 1
```

