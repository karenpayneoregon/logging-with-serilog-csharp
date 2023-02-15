namespace CommandLineArguments.Classes;

public sealed class Appsettings
{
    private static readonly Lazy<Appsettings> Lazy = new(() => new Appsettings());
    public static Appsettings Instance => Lazy.Value;
    public bool UseSeriLog { get; set; }
}