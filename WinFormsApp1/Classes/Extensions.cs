namespace WinFormsApp1.Classes;
public static class Extensions
{

    public static async Task<IEnumerable<FileInfo>> EnumerateFilesAsync(
        this DirectoryInfo directoryInfo, 
        string searchPattern = "*",
        SearchOption searchOption = SearchOption.TopDirectoryOnly) =>
        await Task.Run(() => directoryInfo.EnumerateFiles(searchPattern, searchOption));

    public static async Task<IEnumerable<DirectoryInfo>> SafeEnumerateDirectoriesAsync(
        this DirectoryInfo directoryInfo,
        string searchPattern = "*",
        SearchOption searchOption = SearchOption.TopDirectoryOnly)
    {
        return await Task.Run(() => SafeEnumerateDirectories(directoryInfo, searchPattern, searchOption));
    }
    public static IEnumerable<DirectoryInfo> SafeEnumerateDirectories(
        this DirectoryInfo directoryInfo,
        string searchPattern = "*",
        SearchOption searchOption = SearchOption.TopDirectoryOnly)
    {
        IEnumerable<DirectoryInfo> directories;

        try
        {
            directories = directoryInfo.EnumerateDirectories(searchPattern, searchOption);
        }
        catch
        {
            return Enumerable.Empty<DirectoryInfo>();
        }

        return directories;
    }
}
