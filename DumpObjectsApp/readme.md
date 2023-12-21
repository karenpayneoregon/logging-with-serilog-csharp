# About

Examples for dumping objects to

- Text files
- Visual Studio's Output window

Why? Because there will be times there is a need to record what an operation should return but returns something different.

## Nuget packages

Each work without the other package.

- [ObjectDumper.NET](https://www.nuget.org/packages/ObjectDumper.NET/4.1.3?_src=template)
- [Dumpify](https://www.nuget.org/packages/Dumpify/0.6.3?_src=template)
- [Serilog](https://www.nuget.org/packages/Serilog/3.1.1?_src=template)
- [Serilog.Sinks.File](https://www.nuget.org/packages/Serilog.Sinks.File/5.0.0?_src=template)

## Examples

**File operations**

Using [Globbing](https://learn.microsoft.com/en-us/dotnet/core/extensions/file-globbing) traverse specfic files in the current Visual Solution and write a strong types container to a file and also in the Visual Studio output window and a log file via SeriLog.

**EF Core example**

One a record from a SQL-Server database via EF Core 8, write to a file and also in the Visual Studio output window.

### EF Core

If this is unwanted, feel free to remove the code for EF Core, otherwise before running this project, run the script in the Scripts folder

