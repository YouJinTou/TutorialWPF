using _02_TreeViewsAndValueConverters.Data;
using _02_TreeViewsAndValueConverters.Models;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace _02_TreeViewsAndValueConverters.DirectoryService
{
    public static class DirService
    {
        public static ICollection<DirectoryItem> GetLogicalDrives()
        {
            return Directory.GetLogicalDrives()
                .Select(d => new DirectoryItem() { Path = d, Type = DirectoryType.Drive })
                .ToList();
        }

        public static ICollection<DirectoryItem> GetDirectoryContents(string path)
        {
            var contents = new List<DirectoryItem>();

            contents.AddRange(Directory.GetDirectories(path).Select(d => new DirectoryItem() { Path = d, Type = DirectoryType.Folder }));
            contents.AddRange(Directory.GetFiles(path).Select(d => new DirectoryItem() { Path = d, Type = DirectoryType.File }));

            return contents;
        }

        public static string GetFileFolderName(string path)
        {
            if (string.IsNullOrEmpty(path))
            {
                return string.Empty;
            }

            var normalizedPath = path.Replace('/', '\\');
            var lastSlashIndex = normalizedPath.LastIndexOf('\\');

            if (lastSlashIndex <= 0)
            {
                return path;
            }

            return normalizedPath.Substring(lastSlashIndex + 1);
        }
    }
}
