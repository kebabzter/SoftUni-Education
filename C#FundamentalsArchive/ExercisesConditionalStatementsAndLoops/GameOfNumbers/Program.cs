using System;

namespace GameOfNumbers
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            int m = int.Parse(Console.ReadLine());
            int magicSum = int.Parse(Console.ReadLine());
            int countCombin = 0;
            string lastCombin = string.Empty;
            for (int i = Math.Min(n,m); i <= Math.Max(n,m); i++)
            {
                for (int j = Math.Min(n,m); j <= Math.Max(n,m); j++)
                {
                    int currentSum = i + j;
                    countCombin++;
                    if (currentSum == magicSum)
                    {
                        lastCombin=i +" + "+ j +" = " + magicSum;
                    }
                }
            }
            if (lastCombin==string.Empty)
            {
                Console.WriteLine($"{countCombin} combinations - neither equals {magicSum}");
            }
            else
            {
                Console.WriteLine($"Number found! {lastCombin}");
            }
        }
    }
}
