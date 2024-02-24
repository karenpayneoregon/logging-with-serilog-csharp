using static System.DateTime;
namespace EF_Core2.Classes;

/// <summary>
/// For logging messages from DbContext.
/// </summary>
public class DbContextToFileLogger
{
    private readonly string _fileName = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "LogFiles",
        $"{Now.Year}-{Now.Month}-{Now.Day}", "EF-Log.txt");


    public DbContextToFileLogger(string fileName)
    {
        _fileName = fileName;
    }

    public DbContextToFileLogger()
    {
            
    }
    /// <summary>
    /// append to the existing stream
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

        streamWriter.WriteLine("-----------------------------------------------------------------");

        streamWriter.Flush();
        streamWriter.Close();
    }
}