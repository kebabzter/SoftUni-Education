using System;
using System.Linq;

namespace EqualSums
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] arr = Console.ReadLine()
                        .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                        .Select(int.Parse)
                        .ToArray();
            if (arr.Length == 1)
            {
                Console.WriteLine("0");
                return;
            }
            bool no = false;
            for (int i = 0; i < arr.Length; i++)
            {
                int leftSum = 0;
                int rightSum = 0;
                for (int j = i + 1; j < arr.Length; j++)
                {
                    rightSum += arr[j];
                }
                for (int k = i - 1; k >= 0; k--)
                {
                    leftSum += arr[k];
                }
                if (leftSum == rightSum)
                {
                    Console.WriteLine(i);
                    no = true;
                    break;
                }
            }
            if (!no)
            {
                Console.WriteLine("no");
            }

        }
    }
}
