using System;
using System.Linq;

namespace SumEvenNumbers
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] arrNum = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
            int sum = 0;
            for (int i = 0; i < arrNum.Length; i++)
            {
                if (arrNum[i] % 2 == 0)
                {
                    sum += arrNum[i];
                }
            }
            Console.WriteLine(sum);
        }
    }
}
