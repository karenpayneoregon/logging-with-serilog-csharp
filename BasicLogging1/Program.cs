using BasicLogging1.Classes;
using Serilog;
using Spectre.Console;

namespace BasicLogging1;

internal partial class Program
{
    static void Main(string[] args)
    {
        AnsiConsole.MarkupLine("[cyan]Creating log[/]");
        Console.WriteLine();


        SetupLogging.Development();

        AnsiConsole.MarkupLine("[cyan]Simple logging[/]");
        Console.WriteLine();
        Log.Information("Hello, Serilog!");

        Console.WriteLine();

        Log.Error(new Exception("Bogus"), "Your message goes here");

        Console.WriteLine();

        Log.Warning(new Exception("Bogus"),"Your warning");

        Console.WriteLine();

  
        Person person = new() { Id = 1, FirstName = "Karen", LastName = "Payne"};
        Log.Information("Processed {@Person}", person);
        Log.Information("Bye, Serilog!");
        ExitPrompt();
        Console.ReadLine();

    }


}