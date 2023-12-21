using Microsoft.Extensions.FileSystemGlobbing;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DumpObjectsApp.Classes;
internal class GlobbingOperations
{
    public delegate void OnTraverseFileMatch(FileMatchItem sender);
    /// <summary>
    /// Informs listener of a <see cref="FileMatchItem"/>
    /// </summary>
    public static event OnTraverseFileMatch TraverseFileMatch;
    public delegate void OnDone(string message);
    /// <summary>
    /// Indicates processing has completed
    /// </summary>
    public static event OnDone Done;
    public static async Task Asynchronous(string parentFolder, string[] patterns, string[] excludePatterns)
    {

        Matcher matcher = new();
        matcher.AddIncludePatterns(patterns);
        matcher.AddExcludePatterns(excludePatterns);

        await Task.Run(() =>
        {
            foreach (string file in matcher.GetResultsInFullPath(parentFolder))
            {
                TraverseFileMatch?.Invoke(new FileMatchItem(file));
            }
        });

        Done?.Invoke("Finished - see log file");

    }
}