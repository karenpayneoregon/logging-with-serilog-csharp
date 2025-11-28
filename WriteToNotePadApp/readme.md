# About

:small_orange_diamond: **11/28/2025** faiing on Win11

This code sample uses a third party SeriLog Sink, [serilog-sinks-notepad](https://github.com/serilog-contrib/serilog-sinks-notepad) which writes logs to notepad.

To ensure notepad is open the following code is used.

```csharp
if (Process.GetProcessesByName("notepad").Length == 0)
{
    Process.Start("notepad.exe");
    await Task.Delay(1000);
}
```

Next SeriLog configuration

```csharp
Log.Logger = new LoggerConfiguration()
    .WriteTo.Notepad()
    .CreateLogger();
```