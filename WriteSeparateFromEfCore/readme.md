# About

This project writes logs to a folder per day under LogFiles folder under the app folder using the following for SeriLog and EF Core under the same folder.

See `EF_Core1` project for plain vanilla logging for EF Core without SeriLog.

## Setting up SeriLog

```csharp
public class SetupLogging
{
    public static void Development()
    {

        Log.Logger = new LoggerConfiguration()
            .MinimumLevel.Verbose()
            .WriteTo.Console(theme: AnsiConsoleTheme.Code)
            .WriteTo.File(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "LogFiles", $"{Now.Year}-{Now.Month}-{Now.Day}", "Log.txt"),
                rollingInterval: RollingInterval.Infinite,
                outputTemplate: "[{Timestamp:yyyy-MM-dd HH:mm:ss.fff} [{Level}] {Message}{NewLine}{Exception}")
            .CreateLogger();
    }
}
```

Which is called in Program.cs under `if (builder.Environment.IsDevelopment())`

```csharp
public class Program
{
    public static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

        builder.Services.AddRazorPages();

        IConfigurationRoot configuration = Configurations.GetConfigurationRoot();
        if (builder.Environment.IsDevelopment())
        {

            SetupLogging.Development();

            builder.Services.AddDbContextPool<Context>(options =>
                options.UseSqlServer(configuration.GetConnectionString("DefaultConnection"))
                    .EnableSensitiveDataLogging()
                    .LogTo(new DbContextToFileLogger().Log));
        }
```

## Setting up EF Core

The following class is responsible for EF Core logging.

```csharp
public class DbContextToFileLogger
{
    private readonly string _fileName = 
        Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "LogFiles", $"{Now.Year}-{Now.Month}-{Now.Day}", $"EF_Log.txt");

    /// <summary>
    /// Use to override log file name and path
    /// </summary>
    /// <param name="fileName"></param>
    public DbContextToFileLogger(string fileName)
    {
        _fileName = fileName;
    }

    /// <summary>
    /// Setup to use default file name for logging
    /// </summary>
    public DbContextToFileLogger()
    {

    }
    /// <summary>
    /// append message to the existing stream
    /// </summary>
    /// <param name="message"></param>
    public void Log(string message)
    {

        if (!File.Exists(_fileName))
        {
            File.CreateText(_fileName).Close();
        }

        StreamWriter streamWriter = new(_fileName, true);

        streamWriter.WriteLine(message);

        streamWriter.WriteLine(new string('-', 40));

        streamWriter.Flush();
        streamWriter.Close();
    }
}
```

Which is used in Program.cs, note `Configurations.GetConfigurationRoot()` which is used to read `appsettings.json`

```csharp
IConfigurationRoot configuration = Configurations.GetConfigurationRoot();
if (builder.Environment.IsDevelopment())
{

    SetupLogging.Development();

    builder.Services.AddDbContextPool<Context>(options =>
        options.UseSqlServer(configuration.GetConnectionString("DefaultConnection"))
            .EnableSensitiveDataLogging()
            .LogTo(new DbContextToFileLogger().Log));
}
```

## Folder for logging note

SeriLog will generate folders but not EF Core so I setup the following in this project file in the event EF Core performs a log before SeriLog

```xml
<Target Name="MakeMyDir" AfterTargets="Build">
   <MakeDir Directories="$(OutDir)LogFiles" />
</Target>
```

## Database

If the database table does not exists we create it with a check in ListPage.


```csharp
public ListPageModel(Data.Context context)
{
    _context = context;
    CancellationTokenSource cancellationTokenSource = new(TimeSpan.FromSeconds(1));

    var success = context.CanConnectAsync(cancellationTokenSource.Token);
    if (success == false)
    {
        _context.Database.EnsureDeleted();
        _context.Database.EnsureCreated();
    }
}
```

In the DbContext setup for five records.

```csharp
modelBuilder.Entity<UserLogin>().HasData(
    new UserLogin() { Id = 1, EmailAddress = "payne@comcast.net", Pin = "12345" },
    new UserLogin() { Id = 2, EmailAddress = "billybob@gmail.com", Pin = "55555" },
    new UserLogin() { Id = 3, EmailAddress = "mary@yahoo.com", Pin = "97865" },
    new UserLogin() { Id = 4, EmailAddress = "jimj@gmail.com", Pin = "37179" },
    new UserLogin() { Id = 5, EmailAddress = "adam@comcast.net", Pin = "66666" }
);
```

