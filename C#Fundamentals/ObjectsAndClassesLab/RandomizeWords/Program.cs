using System;

namespace RandomizeWords
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] words = Console.ReadLine()
                 .Split(" ",StringSplitOptions.RemoveEmptyEntries);

            Random rnd = new Random();
            for (int i = 0; i < words.Length; i++)
            {
                string temp = words[i];
                int index = rnd.Next(words.Length);
                words[i] = words[index];
                words[index] = temp;
            }
            Console.WriteLine(string.Join(Environment.NewLine,words));
        }
    }
}
