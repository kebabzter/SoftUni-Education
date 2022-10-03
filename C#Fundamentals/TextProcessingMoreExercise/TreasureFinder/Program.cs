using System;
using System.Linq;
using System.Text;

namespace TreasureFinder
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] key = Console.ReadLine()
                 .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                 .Select(int.Parse)
                 .ToArray();
            
            while (true)
            {
                StringBuilder sb = new StringBuilder();
                string input = Console.ReadLine();
                if (input=="find")
                {
                    break;
                }
                for (int i = 0, j = 0; i < input.Length; i++, j++)
                {
                    if (j > key.Length - 1)
                    {
                        j = 0;
                    }

                    int addSymbol = input[i] - key[j];
                    sb.Append((char)addSymbol);
                }
                int indexStartType = sb.ToString().IndexOf('&');
                int indexEndType = sb.ToString().LastIndexOf('&');
                string type = sb.ToString().Substring(indexStartType + 1, indexEndType - indexStartType - 1);
                int indexStartCoordinates = sb.ToString().IndexOf('<');
                int indexEndCoordinates = sb.ToString().IndexOf('>');
                string coordinates = sb.ToString().Substring(indexStartCoordinates + 1, indexEndCoordinates - indexStartCoordinates - 1);

                Console.WriteLine($"Found {type} at {coordinates}");
            }
        }
    }
}
