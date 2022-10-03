using System;
using System.Linq;

namespace RotateAndSum
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] arr = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
            int k = int.Parse(Console.ReadLine());
            int[] sum = new int[arr.Length];
            for (int i = 0; i < k; i++)
            {
                sum[0]+= arr[arr.Length-1];
                for (int j = 1; j < arr.Length; j++)
                {
                    sum[j] += arr[j-1];
                }
                int temp =arr[arr.Length - 1];
                for (int m = arr.Length-1; m >0; m--)
                {
                    arr[m] = arr[m - 1];
                }
                arr[0] = temp;
            }
            Console.WriteLine(string.Join(" ",sum));
        }
    }
}
