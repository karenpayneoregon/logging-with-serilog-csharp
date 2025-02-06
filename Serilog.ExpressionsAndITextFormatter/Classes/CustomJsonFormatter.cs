using System.Text.Json;
using Serilog.Events;
using Serilog.Formatting;

namespace Serilog.ExpressionsAndITextFormatter.Classes;

/// <summary>
/// Provides a custom implementation of the <see cref="ITextFormatter"/> interface
/// to format log events as JSON objects with specific structure and serialization options.
/// </summary>
public class CustomJsonFormatter : ITextFormatter
{
    /// <summary>
    /// Formats a log event into a JSON representation and writes it to the specified output.
    /// </summary>
    /// <param name="logEvent">
    /// The <see cref="LogEvent"/> to format. This contains details about the log entry, 
    /// including its timestamp, level, message, properties, and any associated exception.
    /// </param>
    /// <param name="output">
    /// The <see cref="TextWriter"/> to which the formatted JSON representation of the log event will be written.
    /// </param>
    /// <remarks>
    /// The method serializes the log event into a structured JSON object, including the following fields:
    /// <list type="bullet">
    /// <item><description><c>Timestamp</c>: The timestamp of the log event in ISO 8601 format.</description></item>
    /// <item><description><c>Level</c>: The severity level of the log event.</description></item>
    /// <item><description><c>Message</c>: The rendered message template with its properties.</description></item>
    /// <item><description><c>Properties</c>: A collection of additional properties associated with the log event.</description></item>
    /// <item><description><c>Exception</c>: The exception details, if any, as a string.</description></item>
    /// </list>
    /// The JSON output is indented for readability.
    /// </remarks>
    /// <exception cref="ArgumentNullException">
    /// Thrown if either <paramref name="logEvent"/> or <paramref name="output"/> is <c>null</c>.
    /// </exception>
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

    /// <summary>
    /// Gets the <see cref="JsonSerializerOptions"/> used to configure the serialization behavior
    /// for formatting log events into JSON.
    /// </summary>
    /// <remarks>
    /// This property defines the options for JSON serialization, including settings such as
    /// indentation for improved readability of the output.
    /// </remarks>
    private static JsonSerializerOptions Options => new() { WriteIndented = true };

}
