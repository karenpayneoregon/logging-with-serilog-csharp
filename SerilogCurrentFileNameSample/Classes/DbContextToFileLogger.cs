using static System.DateTime;
namespace SerilogCurrentFileNameSample.Classes;

/// <summary>
/// For logging messages from DbContext.
/// 
/// DO NOT use in production, only development environment
/// 
/// Totally void of exception handling as this is for use by a developer on their machine
/// were they need the proper permissions to create and write to files.
/// 
/// </summary>
public class DbContextToFileLogger
{
    private readonly string _fileName = Path.Combine(
        AppDomain.CurrentDomain.BaseDirectory, "LogFiles", $"EF_Log{Now.Year}{Now.Month}{Now.Day}.txt");

    /// <summary>
    /// Use to override log file name and path
    /// </summary>
    /// <param name="fileName"></param>
    public DbContextToFileLogger(string fileName)
    {
        _fileName = fileName;
    }

    /// <summary>
    /// Setup to use default file name for logging
    /// </summary>
    public DbContextToFileLogger()
    {

    }
    /// <summary>
    /// append message to the existing stream
    /// </summary>
    /// <param name="message"></param>
    public void Log(string message)
    {

        if (!File.Exists(_fileName))
        {
            File.CreateText(_fileName).Close();
        }

        StreamWriter streamWriter = new(_fileName, true);

        streamWriter.WriteLine(message);

        streamWriter.WriteLine(new string('-', 40));

        streamWriter.Flush();
        streamWriter.Close();
    }
}
