#nullable disable
namespace SqlServerSink.Models;

public class LogEntry
{
    public DateTimeOffset? Timestamp { get; set; }
    public string Level { get; set; }
    public string Message { get; set; }
    public string Exception { get; set; }
}