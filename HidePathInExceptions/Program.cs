using System;
using System.IO;
using System.Threading.Tasks;
using HidePathInExceptions.Classes;
using Serilog.Events;

namespace HidePathInExceptions;

internal partial class Program
{
    static async Task Main(string[] args)
    {
        Console.WriteLine();

        try
        {
            await File.ReadAllLinesAsync("SomeFile.txt");
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
   
        }
        await Task.Delay(0);

        try
        {
            await foreach (var item in DataOperations.GetData(true, false))
            {
                Console.WriteLine(item);
                    
            }
        }
        catch (Exception localException)
        {
            // Using Spectre.Console helper to show exception on the screen in nice colors
            ExceptionHelpers.ColorStandard(localException);
            // Write the exception to the SeriLog log file
            SeriControl.Instance.Logger.Write(LogEventLevel.Error, localException, "Woops");
        }

        Console.ReadLine();
    }
}