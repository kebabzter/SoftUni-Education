using System;

namespace SmallestOfThreeNumbers
{
    class Program
    {
        static void Main(string[] args)
        {
            int firstNum = int.Parse(Console.ReadLine());
            int secondNum = int.Parse(Console.ReadLine());
            int threeNum = int.Parse(Console.ReadLine());
            Console.WriteLine(Smallest(firstNum,secondNum,threeNum));
        }

        private static int Smallest(int firstNum, int secondNum, int threeNum)
        {
            return Math.Min(Math.Min(firstNum,secondNum),threeNum);
        }
    }
}
