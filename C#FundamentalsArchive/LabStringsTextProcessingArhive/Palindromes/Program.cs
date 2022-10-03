using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Palindromes
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] text = Console.ReadLine().Split(new char[] {' ',',','?','.','!' },StringSplitOptions.RemoveEmptyEntries);
            List<string> list = new List<string>();
            foreach (var item in text)
            {
                StringBuilder sb = new StringBuilder();
                var reverseArr = item.ToCharArray().Reverse().ToArray();
                foreach (var symbol in reverseArr)
                {
                    sb.Append(symbol);
                }
                string reverse = sb.ToString();
                if (item==reverse)
                {
                    if (!list.Contains(item))
                    {
                        list.Add(item);
                    }
                }
            }
            Console.WriteLine(string.Join(", ",list.OrderBy(x=>x)));
        }
    }
}
