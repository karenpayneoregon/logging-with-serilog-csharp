using System.Diagnostics;
using System.Runtime.InteropServices;

namespace MultipleSubmitButtons2.Classes;

public class WindowHelper
{
    public static void SetConsoleWindowTitle(WebApplication app, string title)
    {
        if (!app.Environment.IsDevelopment())
        {
            return;
        }

        Process[] processes = Process.GetProcesses();

        var consoleWindowTitle = Path.Combine(AppDomain.CurrentDomain.BaseDirectory,
            string.Concat(AppDomain.CurrentDomain.FriendlyName, ".exe"));
        var p = processes.FirstOrDefault(x => x.MainWindowTitle == consoleWindowTitle);
        SetWindowText(p.MainWindowHandle, title);

    }
    [DllImport("user32.dll")]
    static extern int SetWindowText(IntPtr hWnd, string text);
}
