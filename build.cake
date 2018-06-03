var target = string.IsNullOrEmpty(Argument("target", "Default")) ? "Default" : Argument("target", "Default");

Task("Clean")
    .Does(() => DotNetCoreClean("./src/Blaster.sln"));

Task("Restore")
    .Does(() => DotNetCoreRestore("./src/Blaster.sln", new DotNetCoreRestoreSettings
    {
        ArgumentCustomization = args => args.Append("-r win-x64 /p:Platform=x64")
    }));

Task("Build")
    .IsDependentOn("Restore")
    .Does(() =>
    {
        DotNetCoreBuild("./src/Blaster.sln", new DotNetCoreBuildSettings
        {
            NoRestore = true,
            ArgumentCustomization = args => args.Append("-r win-x64 /p:Platform=x64")
        });
    });

Task("Run")
    .IsDependentOn("Build")
    .Does(() =>
    {
        DotNetCorePublish("./src/Blaster.Blazor/Blaster.Blazor.csproj", new DotNetCorePublishSettings
        {
            // NoRestore = true,            
            Configuration = "Release",
        });
        
        var buildSettings = new DotNetCoreMSBuildSettings()
            .SetConfiguration("Debug")
            .SetRuntime("win-x64")
            .WithProperty("Platform", "x64");

        DotNetCoreMSBuild("./src/Blaster.Chromely/Blaster.Chromely.csproj", buildSettings);
        
        DotNetCoreExecute("./src/Blaster.Chromely/bin/x64/Debug/netcoreapp2.1/Blaster.Chromely.dll", "");
    });

Task("Default")
    .IsDependentOn("Clean");

RunTarget(target);