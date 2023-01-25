using Serilog.Sinks.SystemConsole.Themes;

namespace MultipleSubmitButtons2.Classes;

public class SeriLogCustomThemes
{
    public static SystemConsoleTheme Theme1()
    {
        var customThemeStyles =
            new Dictionary<ConsoleThemeStyle, SystemConsoleThemeStyle>
            {
                {
                    ConsoleThemeStyle.Text, new SystemConsoleThemeStyle
                    {
                        Foreground = ConsoleColor.Green,
                    }
                },
                {
                    ConsoleThemeStyle.String, new SystemConsoleThemeStyle
                    {
                        Foreground = ConsoleColor.Yellow,
                    }
                },
            };

        return new SystemConsoleTheme(customThemeStyles);
    }
}
