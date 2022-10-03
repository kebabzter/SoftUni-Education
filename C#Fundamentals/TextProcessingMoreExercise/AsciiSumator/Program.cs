using System;

namespace AsciiSumator
{
    class Program
    {
        static void Main(string[] args)
        {
            char firstSymbol = char.Parse(Console.ReadLine());
            char secondSymbol = char.Parse(Console.ReadLine());
            string str = Console.ReadLine();
            int min = Math.Min(firstSymbol,secondSymbol);
            int max = Math.Max(firstSymbol,secondSymbol);
            int sum = 0;
            for (int i = 0; i < str.Length; i++)
            {
                if (str[i]>min&&str[i]<max)
                {
                    sum += str[i];
                }
            }
            Console.WriteLine(sum);
        }
    }
}
