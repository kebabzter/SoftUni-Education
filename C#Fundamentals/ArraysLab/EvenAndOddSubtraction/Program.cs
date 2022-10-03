using System;
using System.Linq;

namespace EvenAndOddSubtraction
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] arrNum = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
            int sumEven = 0;
            int sumOdd = 0;
            for (int i = 0; i < arrNum.Length; i++)
            {
                if (arrNum[i] % 2 == 0)
                {
                    sumEven += arrNum[i];
                }
                else
                {
                    sumOdd += arrNum[i];
                }
            }
            Console.WriteLine(sumEven - sumOdd);
        }
    }
}
