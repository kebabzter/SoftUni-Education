using System;
using System.Linq;

namespace Zig_ZagArrays
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            int[] firstArr = new int[n];
            int[] secondArr = new int[n];
            for (int i = 0; i < n; i++)
            {
                int[] currentArr = Console.ReadLine()
                    .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                    .Select(int.Parse)
                    .ToArray();
                if (i%2==0)
                {
                    firstArr[i] = currentArr[0];
                    secondArr[i] = currentArr[1];
                }
                else
                {
                    firstArr[i] = currentArr[1];
                    secondArr[i] = currentArr[0];
                }
            }
            Console.WriteLine(string.Join(" ",firstArr));
            Console.WriteLine(string.Join(" ", secondArr));
        }
    }
}
