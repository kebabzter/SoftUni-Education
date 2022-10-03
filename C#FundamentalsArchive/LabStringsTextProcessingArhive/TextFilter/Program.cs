using System;
using System.Text;

namespace TextFilter
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] words = Console.ReadLine().Split(", ",StringSplitOptions.RemoveEmptyEntries);
            string text = Console.ReadLine();
            foreach (var item in words)
            {
                int length = item.Length;
                if (text.Contains(item))
                {
                    text = text.Replace(item, new string('*', length));
                }
            }
            Console.WriteLine(text);
        }
    }
}
