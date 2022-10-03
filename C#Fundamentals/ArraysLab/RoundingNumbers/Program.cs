using System;
using System.Linq;

namespace RoundingNumbers
{
    class Program
    {
        static void Main(string[] args)
        {
            double[] arrNum = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).Select(double.Parse).ToArray();
            for (int i = 0; i < arrNum.Length; i++)
            {
                Console.WriteLine($"{(decimal)arrNum[i]} => {Math.Round((decimal)arrNum[i], MidpointRounding.AwayFromZero)}");
            }
        }
    }
}
