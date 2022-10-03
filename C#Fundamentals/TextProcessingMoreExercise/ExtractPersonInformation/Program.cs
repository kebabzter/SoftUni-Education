using System;

namespace ExtractPersonInformation
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            for (int i = 0; i < n; i++)
            {
                string input = Console.ReadLine();
                int indexStartName = input.IndexOf('@');
                int indexEndName = input.IndexOf('|');
                string name = input.Substring(indexStartName + 1, indexEndName - indexStartName - 1);
                int indexStartAge = input.IndexOf('#');
                int indexEndAge = input.IndexOf('*');
                string age = input.Substring(indexStartAge + 1, indexEndAge - indexStartAge - 1);
                Console.WriteLine($"{name} is {age} years old.");
            }
        }
    }
}
