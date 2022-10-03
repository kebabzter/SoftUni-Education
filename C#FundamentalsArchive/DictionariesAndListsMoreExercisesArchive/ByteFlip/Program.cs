using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;

namespace ByteFlip
{
    class Program
    {
        static void Main(string[] args)
        {
            List<string> input = Console.ReadLine().Split(" ",StringSplitOptions.RemoveEmptyEntries).ToList();
            var info = input.Where(x => x.Length == 2).ToList();
            info.Reverse();
            StringBuilder sb = new StringBuilder();
            for (int i = 0; i < info.Count; i++)
            {
                info[i]= string.Concat(info[i].Reverse());
                sb.Append((char)int.Parse(info[i], NumberStyles.AllowHexSpecifier));
            }
            Console.WriteLine(sb);
        }
    }
}
