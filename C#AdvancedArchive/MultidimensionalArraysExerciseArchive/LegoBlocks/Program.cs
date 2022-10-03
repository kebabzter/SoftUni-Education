using System;
using System.Linq;

namespace LegoBlocks
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            int[][] jaggedFirst = new int[n][];
            int[][] jaggedSecond = new int[n][];

            for (int r = 0; r < n; r++)
            {
                jaggedFirst[r] = Console.ReadLine()
                    .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                    .Select(int.Parse)
                    .ToArray();
            }
            for (int r = 0; r < n; r++)
            {
                jaggedSecond[r] = Console.ReadLine()
                    .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                    .Select(int.Parse)
                    .ToArray();
            }

            for (int row = 0; row <= (jaggedSecond.GetUpperBound(0)); row++)
            {
                for (int col = 0; col <= (jaggedSecond[row].GetUpperBound(0) / 2); col++)
                {
                    int tempHolder = jaggedSecond[row][col];
                    jaggedSecond[row][col] =jaggedSecond[row][jaggedSecond[row].GetUpperBound(0) -col];
                    jaggedSecond[row][jaggedSecond[row].GetUpperBound(0) -col] = tempHolder;
                }
            }

            bool flag = true;
            for (int r = 1; r < n; r++)
            {
                if (jaggedFirst[0].Length+jaggedSecond[0].Length!= jaggedFirst[r].Length + jaggedSecond[r].Length)
                {
                    flag = false;
                    break;
                }
            }

            if (flag)
            {
                for (int i = 0; i < n; i++)
                {
                    Console.WriteLine($"[{string.Join(", ",jaggedFirst[i])}, {string.Join(", ", jaggedSecond[i])}]");
                }
            }
            else
            {
                int count = 0;
                for (int r = 0; r < n; r++)
                {
                    count += jaggedFirst[r].Length + jaggedSecond[r].Length;
                }
                Console.WriteLine($"The total number of cells is: {count}");
            }
        }
    }
}
