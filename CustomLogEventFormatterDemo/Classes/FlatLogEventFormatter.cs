using Serilog.Events;
using Serilog.Formatting;

namespace CustomLogEventFormatterDemo.Classes
{
    public class FlatLogEventFormatter : ITextFormatter
    {
        public void Format(LogEvent logEvent, TextWriter output)
        {
            logEvent.Properties.ToList().ForEach(e =>
                {
                    output.Write($"{e.Key}={e.Value} ");
                });
            output.WriteLine();
        }
    }
}
