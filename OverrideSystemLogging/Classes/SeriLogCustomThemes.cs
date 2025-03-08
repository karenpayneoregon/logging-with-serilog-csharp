using Serilog.Sinks.SystemConsole.Themes;

namespace OverrideSystemLogging.Classes;

public class SeriLogCustomThemes
{
    /// <summary>
    /// Creates a custom console theme for Serilog logging with predefined styles for various log levels and text elements.
    /// </summary>
    /// <returns>
    /// A <see cref="SystemConsoleTheme"/> instance with customized foreground and background colors for specific log styles.
    /// </returns>
    public static SystemConsoleTheme Theme() =>
        new(new Dictionary<ConsoleThemeStyle, SystemConsoleThemeStyle>()
        {
            { ConsoleThemeStyle.Text, new SystemConsoleThemeStyle { Foreground = ConsoleColor.Green, } },
            { ConsoleThemeStyle.LevelVerbose, new SystemConsoleThemeStyle { Foreground = ConsoleColor.Green, } },
            { ConsoleThemeStyle.String, new SystemConsoleThemeStyle { Foreground = ConsoleColor.Yellow, } },
            { ConsoleThemeStyle.Number, new SystemConsoleThemeStyle { Foreground = ConsoleColor.Cyan, } },
            { ConsoleThemeStyle.Boolean, new SystemConsoleThemeStyle { Foreground = ConsoleColor.Red, } },
            { ConsoleThemeStyle.LevelInformation, new SystemConsoleThemeStyle { Foreground = ConsoleColor.DarkCyan, } },
            { ConsoleThemeStyle.SecondaryText, new SystemConsoleThemeStyle { Foreground = ConsoleColor.White, Background = ConsoleColor.DarkBlue, } },
            { ConsoleThemeStyle.LevelError, new SystemConsoleThemeStyle { Foreground = ConsoleColor.Red, Background = ConsoleColor.Yellow, } }
        });
}
