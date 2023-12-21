using Dumpify;
using DumpObjectsApp.Classes;
using DumpObjectsApp.Data;
using Microsoft.EntityFrameworkCore;
using Serilog;
using Color = System.Drawing.Color;
namespace DumpObjectsApp;

internal partial class Program
{
    private static List<FileMatchItem> FileMatchItems = new();
    static Task Main(string[] args)
    {
        DataExample();
        return FileExample();
    }

    private static Task FileExample()
    {
        GlobbingOperations.TraverseFileMatch += GlobbingOperations_TraverseFileMatch;
        GlobbingOperations.Done += GlobbingOperations_Done;
        var path = DirectoryOperations.GetSolutionInfo().FullName;

        string[] include = { "**/*.cs" };
        string[] exclude =
        {
            "**/*Assembly*.cs",
            "**/*Designer*.cs",
            "**/*.g.i.cs",
            "**/*.g.cs",
            "**/TemporaryGeneratedFile*.cs"
        };

        return GlobbingOperations.Asynchronous(path, include, exclude);
    }

    private static void GlobbingOperations_Done(string message)
    {
        FileMatchItems.DumpTrace();
        File.WriteAllText("Files.txt", FileMatchItems.DumpText());
        Log.Information($"\n{FileMatchItems.DumpText()}");
    }

    private static void GlobbingOperations_TraverseFileMatch(FileMatchItem sender)
    {
        FileMatchItems.Add(sender);
    }

    private static void DataExample()
    {
        using var context = new Context();
        var contact = context
            .Contacts
            .Include(c => c.ContactTypeIdentifierNavigation)
            .Include(c => c.ContactDevices)
            .ThenInclude(c => c.PhoneTypeIdentifierNavigation)
            .FirstOrDefault();

        // check out the options besides DumpStyle
        DumpOptions options = new()
        {
            DumpStyle = DumpStyle.CSharp,
        };

        File.WriteAllText("Contacts1.txt", ObjectDumper.Dump(contact));
        File.WriteAllText("Contacts2.txt", ObjectDumper.Dump(contact, options));
        File.WriteAllText("Contacts3.txt", contact.DumpText());

        contact.DumpTrace();
    }
}