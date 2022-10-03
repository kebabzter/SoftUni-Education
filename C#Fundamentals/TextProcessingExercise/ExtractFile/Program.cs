using System;

namespace ExtractFile
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] path = Console.ReadLine()
                .Split("\\", StringSplitOptions.RemoveEmptyEntries);
            string file = path[path.Length-1];
            int index = file.LastIndexOf(".");
            string fileName = file.Substring(0,index);
            string extention = file.Substring(index+1);
            Console.WriteLine($"File name: {fileName}");
            Console.WriteLine($"File extension: {extention}");
        }
    }
}
