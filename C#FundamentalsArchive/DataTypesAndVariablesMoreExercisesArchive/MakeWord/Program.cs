using System;

namespace MakeWord
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            string result = string.Empty;
            for (int i = 0; i < n; i++)
            {
                result += Console.ReadLine();
            }
            Console.WriteLine($"The word is: {result}");
        }
    }
}
