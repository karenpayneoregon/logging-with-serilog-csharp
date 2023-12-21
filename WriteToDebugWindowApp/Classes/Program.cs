using System.Runtime.CompilerServices;
using WriteToDebugWindowApp.Classes;

// ReSharper disable once CheckNamespace
namespace WriteToDebugWindowApp;
internal partial class Program
{
    [ModuleInitializer]
    public static void Init()
    {
        SetupLogging.Development();
    }
}
