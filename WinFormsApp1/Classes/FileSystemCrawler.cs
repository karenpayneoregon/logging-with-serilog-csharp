using System.Collections.Concurrent;

namespace WinFormsApp1.Classes;

/// <summary>
/// Represents a file system crawler that traverses directories and performs operations on them.
/// </summary>
/// <remarks>
/// This class is designed to recursively explore directories starting from a specified path.
/// It utilizes asynchronous tasks to handle directory traversal efficiently.
/// </remarks>
public class FileSystemCrawler
{
    public int NumFolders { get; set; }
    private readonly ConcurrentQueue<DirectoryInfo> folderQueue = new();
    private readonly ConcurrentBag<Task> tasks = new();

    public void CollectFolders(string path)
    {

        DirectoryInfo directoryInfo = new(path);
        tasks.Add(Task.Run(() => CrawlFolder(directoryInfo)));

        while (tasks.TryTake(out var taskToWaitFor))
        {
            taskToWaitFor.Wait();
        }
    }


    private void CrawlFolder(DirectoryInfo dir)
    {
        try
        {
            DirectoryInfo[] directoryInfos = dir.GetDirectories();

            foreach (DirectoryInfo childInfo in directoryInfos)
            {
                // here may be dragons using enumeration variable as closure!!
                DirectoryInfo di = childInfo;
                tasks.Add(Task.Run(() => CrawlFolder(di)));
            }

            // Do something with the current folder
            // e.g. Console.WriteLine($"{dir.FullName}");
            NumFolders++;
        }
        catch (Exception ex)
        {
            while (ex != null)
            {
                Console.WriteLine($"{ex.GetType()} {ex.Message}\n{ex.StackTrace}");
                ex = ex.InnerException!;
            }
        }
    }
}
