using System;
using System.Linq;

namespace SumArrays
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] arrFirst = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
            int[] arrSecond = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
            long[] result = new long[Math.Max(arrFirst.Length, arrSecond.Length)];
            for (int i = 0; i < Math.Min(arrFirst.Length, arrSecond.Length); i++)
            {
                result[i] = arrFirst[i] + arrSecond[i];
            }
            int index = 0;
            if (arrFirst.Length > arrSecond.Length)
            {
                for (int j = arrSecond.Length; j < arrFirst.Length; j++)
                {
                    result[j] = arrFirst[j] + arrSecond[index];
                    index++;
                    if (index==arrSecond.Length)
                    {
                        index = 0;
                    }
                }
            }
            else
            {
                for (int j = arrFirst.Length; j < arrSecond.Length; j++)
                {
                    result[j] = arrFirst[index] + arrSecond[j];
                    index++;
                    if (index == arrFirst.Length)
                    {
                        index = 0;
                    }
                }
            }
            Console.WriteLine(string.Join(" ",result));
        }
    }
}
