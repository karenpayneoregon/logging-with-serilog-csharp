using Serilog;

namespace JsonLogApp;

internal partial class Program
{
    static void Main(string[] args)
    {
        var defaultSetting = "Information";
        var json = 
            $$"""
             {
               "Logging": {
                 "LogLevel": {
                   "Default": "{{defaultSetting}}",
                   "Microsoft": "Warning",
                   "Microsoft.Hosting.Lifetime": "Information"
                 }
               },
               "ConnectionStrings": {
                 "LogDatabase": "Data Source=.\\SQLEXPRESS;Database=Logging;Integrated Security=SSPI;encrypt=optional"
               }
             }
             """;

        SeriLogForJson();
        Log.Information("From appsettings.json {P1}", json);
        Console.WriteLine();
        SeriLogSimple();
        Log.Information("From appsettings.json {P1}", json);

        Console.ReadLine();
    }
}