using WinFormsApp1.Classes;

namespace WinFormsApp1;

internal static class Program
{

    [STAThread]
    static void Main()
    {
        ApplicationConfiguration.Initialize();
        SetupLogging.Development();
        Application.Run(new Form1());
    }
}