using System;

namespace TextFilter
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] bannedWords = Console.ReadLine()
                 .Split(", ", StringSplitOptions.RemoveEmptyEntries);
            string text = Console.ReadLine();
            foreach (var item in bannedWords)
            {
                int count = item.Length;
                string str = new string('*', count);
                text=text.Replace(item, str);
            }
            Console.WriteLine(text);
        }
    }
}
