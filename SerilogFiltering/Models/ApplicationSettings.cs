namespace SerilogFiltering.Models;

/// <summary>
/// Represents the application settings used for configuring various aspects of the application.
/// </summary>
/// <remarks>
/// This class is primarily used to store configuration values, such as whether to enable Serilog timing functionality.
/// The settings are typically loaded from a configuration file, such as "appsettings.json".
/// </remarks>
public class ApplicationSettings
{
    /// <summary>
    /// Gets or sets a value indicating whether Serilog timing functionality is enabled.
    /// </summary>
    /// <value>
    /// <c>true</c> if Serilog timing is enabled; otherwise, <c>false</c>.
    /// </value>
    /// <remarks>
    /// This property is used to determine whether Serilog timing should be utilized for logging.
    /// The value is typically configured in the "appsettings.json" file under the "ApplicationSettings" section.
    /// </remarks>
    public bool UseSerilogTiming { get; set; }
}


