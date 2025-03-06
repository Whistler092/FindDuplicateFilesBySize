﻿
using System.Linq;

string rootPath = @"C:\Users\ramir\OneDrive\Album de Fotografias\";
string folderAllowedToDelete = @"\Whatsapp\";
var canDeleteFile = false;

//Capture parameter Delete=true from command line for allow delete
if (args.Length > 0)
{
    canDeleteFile = args[0].Contains("Delete=true");
}

string[] files = Directory.GetFiles(rootPath, "*.*", SearchOption.AllDirectories);

var groups = files.GroupBy(f => new FileInfo(f).Length);
foreach (var group in groups.OrderBy(i => i.First().Length))
{
    if (group.Count() <= 1)
    {
        continue;
    }
    
    foreach (var filesByName in group.GroupBy(f => new FileInfo(f).Name))
    {
        if (filesByName.Count() <= 1)
        {
            continue;
        }
        Console.WriteLine("Duplicate file size: {0}", ConvertBytesToHumanRedable(group.Key));
        Console.WriteLine($"\t{filesByName.Key} - {filesByName.Count()} files");
        var count = 0;
        foreach (var file in filesByName)
        {

            if (file.Contains(folderAllowedToDelete))
            {
                Console.WriteLine($"\t{file} - Allowed to delete {canDeleteFile}");

                if (canDeleteFile && count == 0)
                {
                    File.Delete(file);
                    count++;
                }
                continue;

            }
            Console.WriteLine($"\t{file}");

        }



    }
}

//Delete empty folders of rootPath
foreach (var directory in Directory.GetDirectories(rootPath, "*", SearchOption.AllDirectories))
{
    if (Directory.GetFiles(directory).Length == 0 && Directory.GetDirectories(directory).Length == 0)
    {
        Console.WriteLine($"Deleting empty folder: {directory}");
        Directory.Delete(directory, false);
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