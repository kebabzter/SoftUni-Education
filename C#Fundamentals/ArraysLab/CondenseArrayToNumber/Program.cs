using System;
using System.Linq;

namespace CondenseArrayToNumber
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] arrNum = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
            while (arrNum.Length > 1)
            {
                int[] condensed = new int[arrNum.Length - 1];
                for (int i = 0; i < condensed.Length; i++)
                {
                    condensed[i] = arrNum[i] + arrNum[i + 1];
                }
                arrNum = condensed;
            }
            Console.WriteLine(arrNum[0]);
        }
    }
}
