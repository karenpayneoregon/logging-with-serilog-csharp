using Serilog;
using Serilog.Sinks.WinForms.Base;

namespace WinFormsApp2;

internal static class Program
{
    [STAThread]
    static void Main()
    {
        ConfigureSerilog();
        ApplicationConfiguration.Initialize();
        Application.Run(new Form1());
    }
    private static void ConfigureSerilog()
    {
        Log.Logger = new LoggerConfiguration()
            .Enrich.FromLogContext()
            .WriteToGridView()
            .WriteToJsonTextBox()
            .WriteToSimpleAndRichTextBox()
            .CreateLogger();
    }
}