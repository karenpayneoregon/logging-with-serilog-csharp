using Microsoft.EntityFrameworkCore;
using SerilogCurrentFileNameSample.Classes;
using SerilogCurrentFileNameSample.Classes.Configurations;
using SerilogCurrentFileNameSample.Data;
using Spectre.Console;

namespace SerilogCurrentFileNameSample;
internal partial class Program
{
    static async Task Main(string[] args)
    {
        Console.WriteLine(ConfigurationHelpers.GetSerilogFileName());
        Console.WriteLine(ConfigurationHelpers.GetSerilogFolder());
        await using var context = new Context();
        var item = await context.BirthDays.FirstOrDefaultAsync();
        
        var birthDate = item!.BirthDate!.Value.AddDays(1);
        item.BirthDate = birthDate;

        /*
         * This invokes SaveChangesAsync which is intercepted by AuditInterceptor and logs the changes
         */
        await context.SaveChangesAsync();
        
        AnsiConsole.MarkupLine("[cyan]Done, check out the log file under[/] [yellow]LogFiles[/] [cyan]from the app folder[/]");
        AnsiConsole.MarkupLine($"[orchid]{FileHelper.GetLogFileName()!.FullName}[/]");
        
        SpectreConsoleHelpers.ExitPrompt();
    }
}
