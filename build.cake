var target = string.IsNullOrEmpty(Argument("target", "Default")) ? "Default" : Argument("target", "Default");

Task("Clean")
    .Does(() => DotNetCoreClean("./src/Blaster.sln"));

Task("Restore")
    .Does(() => DotNetCoreRestore("./src/Blaster.sln"));

Task("Build")
    .IsDependentOn("Restore")
    .Does(() =>
    {
        DotNetCoreBuild("./src/Blaster.sln", new DotNetCoreBuildSettings
        {
            NoRestore = true
        });
    });

Task("Run")
    .IsDependentOn("Build")
    .Does(() =>
    {
        DotNetCorePublish("./src/Blaster.Blazor/Blaster.Blazor.csproj", new DotNetCorePublishSettings
        {
            NoRestore = true,            
            Configuration = "Release",
        });

        DotNetCoreBuild("./src/Blaster.sln", new DotNetCoreBuildSettings
        {
            NoRestore = true
        });
    });

Task("Default")
    .IsDependentOn("Clean");

RunTarget(target);