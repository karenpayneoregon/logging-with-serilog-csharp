﻿using Serilog.Sinks.SystemConsole.Themes;

namespace SeriLogLibrary;

/// <summary>
/// Feel free to change the colors
/// </summary>
public class SeriLogCustomThemes
{

    /// <summary>
    /// Custom theme.<br/>
    /// Text: Green<br/>
    /// String: Yellow<br/>
    /// Number: Cyan<br/>
    /// Boolean: Red<br/>
    /// Error: Red on Yellow<br/>
    /// </summary>
    public static SystemConsoleTheme KarenConsoleTheme() =>
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

    /// <summary>
    /// Custom theme.<br/>
    /// Text: Green<br/>
    /// String: Yellow<br/>
    /// Number: Cyan<br/>
    /// Boolean: White<br/>
    /// </summary>
    public static SystemConsoleTheme Theme2()
    {
        Dictionary<ConsoleThemeStyle, SystemConsoleThemeStyle> customThemeStyles =
            new()
            {
                {
                    ConsoleThemeStyle.Text, new SystemConsoleThemeStyle
                    {
                        Foreground = ConsoleColor.Blue,
                    }
                },
                {
                    ConsoleThemeStyle.String, new SystemConsoleThemeStyle
                    {
                        Foreground = ConsoleColor.Yellow,
                    }
                },
                {
                    ConsoleThemeStyle.Number, new SystemConsoleThemeStyle
                    {
                        Foreground = ConsoleColor.Cyan,
                    }
                },
                {
                    ConsoleThemeStyle.Boolean, new SystemConsoleThemeStyle
                    {
                        Foreground = ConsoleColor.White,
                    }
                },
                {
                    ConsoleThemeStyle.LevelInformation, new SystemConsoleThemeStyle
                    {
                        Foreground = ConsoleColor.DarkGreen
                    }
                }
            };

        return new SystemConsoleTheme(customThemeStyles);

    }

    /// <summary>
    /// Custom theme.<br/>
    /// Text: Green<br/>
    /// String: Cyan<br/>
    /// Number: Yellow<br/>
    /// Boolean: White<br/>
    /// </summary>
    public static SystemConsoleTheme Theme3()
    {
        Dictionary<ConsoleThemeStyle, SystemConsoleThemeStyle> customThemeStyles =
            new()
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
                        Foreground = ConsoleColor.Cyan
                    }
                },
                {
                    ConsoleThemeStyle.Number, new SystemConsoleThemeStyle
                    {
                        Foreground = ConsoleColor.Yellow,
                    }
                },
                {
                    ConsoleThemeStyle.Boolean, new SystemConsoleThemeStyle
                    {
                        Foreground = ConsoleColor.White,
                    }
                },
            };

        return new SystemConsoleTheme(customThemeStyles);

    }
    public static SystemConsoleTheme JsonTheme()
    {
        Dictionary<ConsoleThemeStyle, SystemConsoleThemeStyle> customThemeStyles =
            new()
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
                        Foreground = ConsoleColor.DarkCyan,
                    }
                },
                {
                    ConsoleThemeStyle.Number, new SystemConsoleThemeStyle
                    {
                        Foreground = ConsoleColor.Cyan,
                    }
                },
                {
                    ConsoleThemeStyle.Boolean, new SystemConsoleThemeStyle
                    {
                        Foreground = ConsoleColor.White,
                    }
                },
                {
                    ConsoleThemeStyle.LevelInformation, new SystemConsoleThemeStyle
                    {
                        Foreground = ConsoleColor.DarkGreen
                    }
                }
            };

        return new SystemConsoleTheme(customThemeStyles);

    }
}
