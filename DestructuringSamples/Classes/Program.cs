using System.Reflection;
using System.Runtime.CompilerServices;

// ReSharper disable once CheckNamespace
namespace DestructuringSamples;
internal partial class Program
{
    [ModuleInitializer]
    public static void Init()
    {
        AnsiConsole.MarkupLine("");
        var assembly = Assembly.GetEntryAssembly();
        var product = assembly?.GetCustomAttribute<AssemblyProductAttribute>()?.Product;

        Console.Title = product!;
        WindowUtility.SetConsoleWindowPosition(WindowUtility.AnchorWindow.Center);

    }
}
