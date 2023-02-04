using System.Text.Json;
using CombinedConfigDemo.Classes;
using CombinedConfigDemo.Data;
using Serilog;
using Spectre.Console;

namespace CombinedConfigDemo
{
    // This sample app reads connection string and column options from appsettings.json
    // while schema name, table name and autoCreateSqlTable are supplied programmatically
    // as parameters to the MSSqlServer() method.
    internal static partial class Program
    {


        public static void Main()
        {

            while (true)
            {
                Console.Clear();

                var menuItem = AnsiConsole.Prompt(MenuOperations.SelectionPrompt());
                if (menuItem.Id != -1)
                {
                    menuItem.Action();
                }
                else
                {
                    return;
                }
            }

        }

        private static void CreateSomeLogs()
        {
            Log.Information("Hello {Name} from thread {ThreadId}",
                Environment.GetEnvironmentVariable("USERNAME"),
                Thread.CurrentThread.ManagedThreadId);

            Log.Information("First entry");
            Log.Warning("No coins remain at position {@Position}", new { Lat = 25, Long = 134 });
            Log.Error(new JsonException("Something is wrong"), "Json issue");
            Log.Information("Last entry");

            try
            {
                var lines = File.ReadAllLines("Customers.txt");
            }
            catch (Exception e)
            {
                Log.Error(e, "xxxx");
            }

            Log.CloseAndFlush();
        }
    }
}
