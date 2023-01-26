using Serilog;
using System.Diagnostics;

namespace WriteToNotePadApp;

internal partial class Program
{
    static async Task Main(string[] args)
    {

        if (Process.GetProcessesByName("notepad").Length == 0)
        {
            AnsiConsole.MarkupLine("[cyan]Had to start[/] [yellow]notepad[/]");
            Process.Start("notepad.exe");
            await Task.Delay(1000);
        }
        else
        {
            AnsiConsole.MarkupLine("[cyan]Using opened[/] [yellow]notepad[/]");
        }

        Log.Logger = new LoggerConfiguration()
            .WriteTo.Notepad()
            .CreateLogger();

        Log.Information("Hello, world!");

        try
        {
            await File.ReadAllLinesAsync("C:\\Data\\DoesNotExists.txt");
        }
        catch (Exception exception)
        {
            Log.Error(exception.ToString());
        }

        await Log.CloseAndFlushAsync();

        ExitPrompt();
        Console.ReadLine();
    }
}