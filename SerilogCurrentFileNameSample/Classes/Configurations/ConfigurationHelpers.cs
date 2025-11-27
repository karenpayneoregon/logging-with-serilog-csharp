using Microsoft.Extensions.Configuration;

namespace SerilogCurrentFileNameSample.Classes.Configurations;
public static class ConfigurationHelpers
{
    /// <summary>
    /// Retrieves the Serilog configuration section from the application's configuration file.
    /// </summary>
    /// <returns>
    /// An instance of <see cref="SerilogSection"/> 
    /// containing the Serilog configuration settings.
    /// </returns>
    /// <remarks>
    /// This method reads the "SerilogSection" from the "appsettings.json" file and binds it to 
    /// a <see cref="SerilogSection"/> object.
    /// </remarks>
    public static SerilogSection GetSerilogSection()
    {
        IConfiguration config = new ConfigurationBuilder()
            .SetBasePath(Directory.GetCurrentDirectory())
            .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
            .Build();

        var section = new SerilogSection();
        config.GetSection("SerilogSection").Bind(section);
        return section;
    }
    
    /// <summary>
    /// Retrieves the file name for the Serilog log file from the application's configuration.
    /// </summary>
    /// <returns>
    /// A <see cref="string"/> representing the file name of the Serilog log file.
    /// </returns>
    /// <remarks>
    /// This method accesses the Serilog configuration section in the application's configuration file
    /// and extracts the file name specified for logging.
    /// </remarks>
    public static string GetSerilogFileName() => GetSerilogSection().FileName;
    
    /// <summary>
    /// Retrieves the folder path for the Serilog log files from the application's configuration.
    /// </summary>
    /// <returns>
    /// A <see cref="string"/> representing the folder path where the Serilog log files are stored.
    /// </returns>
    /// <remarks>
    /// This method accesses the Serilog configuration section in the application's configuration file
    /// and extracts the folder path derived from the configured log file name.
    /// </remarks>
    public static string GetSerilogFolder() => GetSerilogSection().Folder;
}
