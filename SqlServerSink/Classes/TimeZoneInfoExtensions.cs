namespace SqlServerSink.Classes;
public static class TimeZoneInfoExtensions
{
    public static string GetDisplayNameWithCurrentOffset(this TimeZoneInfo timezone, DateTimeOffset date)
    {
        if (!timezone.SupportsDaylightSavingTime)
        {
            return timezone.DisplayName;
        }

        var displayNameWithoutOffset = timezone.DisplayName.Remove(0, 11);

        var currentOffset = TimeZoneInfo.ConvertTime(date, timezone).Offset;
        var currentOffsetHoursMinutes = currentOffset.ToString("hh\\:mm");

        return currentOffset < TimeSpan.Zero ? 
            $"(UTC-{currentOffsetHoursMinutes}){displayNameWithoutOffset}" : 
            $"(UTC+{currentOffsetHoursMinutes}){displayNameWithoutOffset}";
    }
}
