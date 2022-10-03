using System;
using System.Linq;

namespace FoldАndSum
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] arr = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse).ToArray();
            int k = arr.Length / 4;
            int[] arrFirst = new int[2 * k];
            int[] arrSecond = new int[2 * k];
            int index = 0;
            for (int i = k - 1; i >= 0; i--)
            {
                arrFirst[index] = arr[i];
                index++;
            }
            for (int j = 1; j <= k; j++)
            {
                arrFirst[index] = arr[arr.Length - j];
                index++;
            }
            for (int m = 0; m < 2 * k; m++)
            {
                arrSecond[m] = arr[k + m];
            }
            int[] arrSum = new int[2 * k];
            for (int p = 0; p < 2 * k; p++)
            {
                arrSum[p] = arrFirst[p] + arrSecond[p];
            }
            Console.WriteLine(string.Join(" ", arrSum));
        }
    }
}
