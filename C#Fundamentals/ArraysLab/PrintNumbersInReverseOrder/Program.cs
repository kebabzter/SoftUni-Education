using System;
using System.Linq;

namespace PrintNumbersInReverseOrder
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            int[] arrNum = new int[n];
            for (int i = 0; i < arrNum.Length; i++)
            {
                arrNum[i] = int.Parse(Console.ReadLine());
            }
            Console.WriteLine(string.Join(" ", arrNum.Reverse()));
        }
    }
}
