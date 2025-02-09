using System.Runtime.CompilerServices;
using Microsoft.Extensions.Configuration;
using SerilogFiltering.Classes;
using SerilogFiltering.Models;

// ReSharper disable once CheckNamespace
namespace SerilogFiltering;
internal partial class Program
{
    /// <summary>
    /// Initializes the application by setting up logging and configuring the console window.
    /// </summary>
    /// <remarks>
    /// This method is marked with the <see cref="ModuleInitializerAttribute"/> 
    /// to ensure it is executed automatically during the module's initialization phase.
    /// It performs the following actions:
    /// <list type="bullet">
    /// <item>
    /// <description>Configures logging for the development environment using <see cref="SetupLogging.Development"/>.</description>
    /// </item>
    /// <item>
    /// <description>Sets the console window title to "Code sample".</description>
    /// </item>
    /// <item>
    /// <description>Centers the console window on the screen using <see cref="WindowUtility.SetConsoleWindowPosition"/>.</description>
    /// </item>
    /// </list>
    /// </remarks>
    [ModuleInitializer]
    public static void Init()
    {
        SetupLogging.Development();
        Console.Title = "Code sample";
        WindowUtility.SetConsoleWindowPosition(WindowUtility.AnchorWindow.Center);
    }

    /// <summary>
    /// Determines whether Serilog timing functionality should be used based on the application settings.
    /// </summary>
    /// <remarks>
    /// This method reads the configuration from the "appsettings.json" file and retrieves the 
    /// <see cref="ApplicationSettings.UseSerilogTiming"/> value to decide whether to enable Serilog timing.
    /// </remarks>
    /// <returns>
    /// <c>true</c> if Serilog timing is enabled; otherwise, <c>false</c>.
    /// </returns>
    private static bool UseSerilogTiming() 
        => ConfigurationRoot().GetSection("ApplicationSettings").Get<ApplicationSettings>().UseSerilogTiming;

    /// <summary>
    /// Builds and retrieves the application's configuration root.
    /// </summary>
    /// <remarks>
    /// This method constructs an <see cref="IConfigurationRoot"/> by reading the "appsettings.json" file 
    /// located in the application's base directory. The configuration is set to reload automatically 
    /// when the file changes.
    /// </remarks>
    /// <returns>
    /// An instance of <see cref="IConfigurationRoot"/> representing the application's configuration.
    /// </returns>
    private static IConfigurationRoot ConfigurationRoot() =>
        new ConfigurationBuilder()
            .SetBasePath(AppContext.BaseDirectory)
            .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
            .Build();
}
