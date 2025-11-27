#nullable disable
namespace SerilogCurrentFileNameSample.Classes.Configurations;

/// <summary>
/// Represents the configuration section for Serilog.
/// </summary>
public class SerilogSection
{
    public string FileName { get; set; }
    public string Folder => Path.GetDirectoryName(FileName);
}