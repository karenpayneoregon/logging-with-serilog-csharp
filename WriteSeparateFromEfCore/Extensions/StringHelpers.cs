using System.Text.RegularExpressions;

namespace WriteSeparateFromEfCore.Extensions;

public class StringHelpers
{
    public static string NextValue(string sender)
    {
        string value = Regex.Match(sender, "[0-9]+$").Value;
        return sender[..^value.Length] + (long.Parse(value) + 1)
            .ToString().PadLeft(value.Length, '0');
    }
}
