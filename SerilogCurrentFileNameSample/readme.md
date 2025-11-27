# About

An example project demonstrating EF Core [SaveChangesInterceptor](https://learn.microsoft.com/en-us/dotnet/api/microsoft.entityframeworkcore.diagnostics.savechangesinterceptor?view=efcore-10.0) to log changes made to data.

## Get last logged file name in Serilog

[Serilog](https://www.nuget.org/packages/Serilog/4.3.0?_src=template) is configured to write log files to a specific folder with rolling files. This example demonstrates how to retrieve the most recent log file name using `Microsoft.Extensions.FileSystemGlobbing`.

```csharp
public static class FileHelper
{

    public static FileInfo? GetLogFileName()
    {
        var rootPath = Config.JsonRoot().GetSection(nameof(SerilogSection)).Get<SerilogSection>()!.Folder;
        var pattern = "**/*.txt";


        if (!Directory.Exists(rootPath))
            throw new DirectoryNotFoundException(rootPath);

        var matcher = new Matcher();
        matcher.AddInclude(pattern);

        var directoryInfo = new DirectoryInfo(rootPath);
        var dirWrapper = new DirectoryInfoWrapper(directoryInfo);

        var matchResult = matcher.Execute(dirWrapper);

        var newest = matchResult.Files
            .Select(f => new FileInfo(Path.Combine(rootPath, f.Path)))
            .OrderByDescending(f => f.LastWriteTimeUtc)
            .FirstOrDefault();
        
        return newest;
    }
}
```

## Newtonsoft.Json

Json.net is used to serialize the EF Core entity changes to JSON format for logging which is a better fit in this case than the default System.Text.Json.
