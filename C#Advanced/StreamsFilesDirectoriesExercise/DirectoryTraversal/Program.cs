using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace DirectoryTraversal
{
    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, List<FileInfo>> filesExtensions = new Dictionary<string, List<FileInfo>>();
            string path = Console.ReadLine();
            string[] files=Directory.GetFiles(path);

            foreach (string file in files)
            {
                FileInfo info = new FileInfo(file);
                string extension = info.Extension;
                if (!filesExtensions.ContainsKey(extension))
                {
                    filesExtensions.Add(extension,new List<FileInfo>());
                }
                filesExtensions[extension].Add(info);
            }

            using (StreamWriter writer=new StreamWriter(Environment.GetFolderPath(Environment.SpecialFolder.Desktop)+"/report.txt"))
            {
                foreach (var item in filesExtensions.OrderByDescending(x=>x.Value.Count).ThenBy(x=>x.Key))
                {
                    writer.WriteLine(item.Key);
                    foreach (var info in item.Value.OrderBy(x=>Math.Ceiling((double)x.Length/1024)))
                    {
                        writer.WriteLine($"--{info.Name} - {Math.Ceiling((double)info.Length/1024)}kb");
                    }
                }
            }
        }
    }
}
