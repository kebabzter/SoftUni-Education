using System;
using System.Linq;

namespace EqualArrays
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] arrNum = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
            int[] arrNum2 = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
            bool flag = true;
            for (int i = 0; i < arrNum.Length; i++)
            {
                if (arrNum[i] != arrNum2[i])
                {
                    flag = false;
                    Console.WriteLine($"Arrays are not identical. Found difference at {i} index");
                    break;
                }
            }
            if (flag)
            {
                Console.WriteLine($"Arrays are identical. Sum: {arrNum.Sum()}");
            }
        }
    }
}
