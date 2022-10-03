using System;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;

namespace MergeFiles
{
    class Program
    {
        static async Task Main(string[] args)
        {
            string[] linesOne = await File.ReadAllLinesAsync("FileOne.txt");
            string[] linesTwo = await File.ReadAllLinesAsync("FileTwo.txt");
            List<string> result = new List<string>();
            for (int i = 0; i < Math.Min(linesOne.Length, linesTwo.Length); i++)
            {
                result.Add(linesOne[i]);
                result.Add(linesTwo[i]);
            }
            if (linesOne.Length>linesTwo.Length)
            {
                for (int i = Math.Min(linesOne.Length, linesTwo.Length); i < linesOne.Length; i++)
                {
                    result.Add(linesOne[i]);
                }
            }
            else
            {
                for (int i = Math.Min(linesOne.Length, linesTwo.Length); i < linesOne.Length; i++)
                {
                    result.Add(linesTwo[i]);
                }
            }
            await File.WriteAllLinesAsync("output.txt", result);
        }
    }
}
