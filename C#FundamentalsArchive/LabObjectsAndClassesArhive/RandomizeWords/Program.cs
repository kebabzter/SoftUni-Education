using System;

namespace RandomizeWords
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] words = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);
            Random rnd = new Random();
            for (int i = 0; i < words.Length; i++)
            {
                int index = rnd.Next(0, words.Length);
                string temp = words[i];
                words[i] = words[index];
                words[index] = temp;
            }
            foreach (var item in words)
            {
                Console.WriteLine(item);
            }
        }
    }
}
