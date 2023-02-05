namespace ConditionalLoggingToggle.Classes;

public static class BoolExtensions
{
    public static string ToOnOff(this bool value) => value ? "On" : "Off";
}