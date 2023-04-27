
string rootPath = @"D:\OneDrive";

string[] files = Directory.GetFiles(rootPath, "*.*", SearchOption.AllDirectories);

var groups = files.GroupBy(f => new FileInfo(f).Length);
foreach (var group in groups.OrderBy(i => i.First().Length))
{
    if (group.Count() > 1)
    {
        Console.WriteLine("Duplicate file size: {0}", ConvertBytesToHumanRedable(group.Key));
        foreach (var file in group)
        {
            Console.WriteLine("\t{0}", file);
        }
    }
}

string ConvertBytesToHumanRedable(long fileLength)
{
    string[] sizes = { "B", "KB", "MB", "GB", "TB" };
    double len = fileLength;
    int order = 0;
    while (len >= 1024 && order < sizes.Length - 1)
    {
        order++;
        len = len / 1024;
    }
    return String.Format("{0:0.##} {1}", len, sizes[order]);
    
}

Console.WriteLine(
    "Press any key to continue...");