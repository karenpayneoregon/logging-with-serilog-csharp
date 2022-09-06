using Serilog;
using Spectre.Console;

namespace BasicLogging1;

internal class Program
{
    static void Main(string[] args)
    {
        AnsiConsole.MarkupLine("[cyan]Creating log[/]");
        Console.WriteLine();

        using var log = new LoggerConfiguration()
            .WriteTo.Console()
            .CreateLogger();

        AnsiConsole.MarkupLine("[cyan]Simple logging[/]");
        Console.WriteLine();
        log.Information("Hello, Serilog!");

        Console.WriteLine();

        log.Error(new Exception("Bogus"), "Your message goes here");

        Console.WriteLine();

        log.Warning(new Exception("Bogus"),"Your warning");

        Console.WriteLine();

  
        Person person = new() { Id = 1, FirstName = "Karen", LastName = "Payne"};
        log.Information("Processed {@Person}", person);
        log.Information("Bye, Serilog!");
        Console.ReadLine();

    }


}