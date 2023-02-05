namespace ConditionalLoggingToggle.Models;

public class Connectionsconfiguration
{
    public string ActiveEnvironment { get; set; }
    public string Development { get; set; }
    public string Stage { get; set; }
    public string Production { get; set; }
}