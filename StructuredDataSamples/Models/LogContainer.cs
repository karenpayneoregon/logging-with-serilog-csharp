namespace StructuredDataSamples.Models;

public class LogContainer
{
    public DateTime Timestamp { get; set; }
    public string Level { get; set; }
    public string MessageTemplate { get; set; }
    public Properties Properties { get; set; }
}