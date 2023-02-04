using System.Text.Json;
using CombinedConfigDemo.Classes;
using Serilog;


namespace CombinedConfigDemo;

// This sample app reads connection string and column options from appsettings.json
internal static partial class Program
{
    public static void Main()
    {
        MenuOperations.Run();
    }
}