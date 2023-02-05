using System.Text.Json;
using ConditionalLoggingToggle.Classes;
using ConditionalLoggingToggle.Models;

namespace ConditionalLoggingToggle;

internal partial class Program
{
    static void Main(string[] args)
    {

       
        var fileName = Path.Combine(
            DirectoryHelper.UpLevel(AppDomain.CurrentDomain.BaseDirectory, 4),
            "ConditionalLogging\\bin\\Debug\\net7.0", "appsettings.json");

        if (!File.Exists(fileName))
        {
            AnsiConsole.MarkupLine("[white on red]Missing settings file[/]");
            Console.WriteLine(fileName);
            ExitPrompt();
            return;
        }

        var json = File.ReadAllText(fileName);
        Settings settings = JsonSerializer.Deserialize<Settings>(json);
        var question = "Turn on logging?";
        if (settings.Debug.LogSqlCommand)
        {
            AnsiConsole.MarkupLine($"[yellow]Currently logging is on[/]");
            question = "Turn off logging?";
        }
        else
        {
            AnsiConsole.MarkupLine($"[yellow]Currently logging is turned off[/]");
        }

        if (Prompts.AskConfirmation(question))
        {
            settings.Debug.LogSqlCommand = !settings.Debug.LogSqlCommand;
            var options = new JsonSerializerOptions { WriteIndented = true };
            string jsonString = JsonSerializer.Serialize(settings, options);
            File.WriteAllText(fileName, jsonString);
            AnsiConsole.MarkupLine($"[yellow]Log is[/] [white]{settings.Debug.LogSqlCommand.ToOnOff()}[/]");
        }

        ExitPrompt();
    }
    
}