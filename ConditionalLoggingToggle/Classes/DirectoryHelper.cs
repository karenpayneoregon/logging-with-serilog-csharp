namespace ConditionalLoggingToggle.Classes;
public static class DirectoryHelper
{
    /// <summary>
    /// Get a parent folder by level
    /// </summary>
    /// <param name="folderName">folder to start with</param>
    /// <param name="level">level to traverse upwards </param>
    /// <returns>folder at level or root of drive</returns>
    public static string UpperFolder(this string folderName, int level)
    {
        var folderList = new List<string>();

        while (!string.IsNullOrWhiteSpace(folderName))
        {
            var parentFolder = Directory.GetParent(folderName);
            if (parentFolder == null) break;
            folderName = Directory.GetParent(folderName)?.FullName;
            folderList.Add(folderName);
        }

        return folderList.Count > 0 &&
               level > 0 ? level - 1 <= folderList.Count - 1 ?
            folderList[level - 1] :
            folderName : folderName;
    }


    public static string UpLevel(string sender, int level)
        => UpperFolder(Path.GetDirectoryName(sender), level);




}