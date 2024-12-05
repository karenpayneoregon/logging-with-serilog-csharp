using System.Text.Json;
using Serilog.Events;
using Serilog.Formatting;

namespace Serilog.ExpressionsAndITextFormatter.Classes;
public class CustomJsonFormatter : ITextFormatter
{
    public void Format(LogEvent logEvent, TextWriter output)
    {
        var logObject = new
        {
            Timestamp = logEvent.Timestamp.ToString("yyyy-MM-ddTHH:mm:ss.fffZ"), // ISO 8601 format
            Level = logEvent.Level.ToString(),
            Message = logEvent.MessageTemplate.Render(logEvent.Properties),
            Properties = logEvent.Properties,  // Serialize all properties
            Exception = logEvent.Exception?.ToString() // Exception as string if present
        };

        // Serialize to JSON
        var json = JsonSerializer.Serialize(logObject, Options);
        output.WriteLine(json);
    }
    private static JsonSerializerOptions Options =>
        new()
        {
            WriteIndented = true
        };
}
