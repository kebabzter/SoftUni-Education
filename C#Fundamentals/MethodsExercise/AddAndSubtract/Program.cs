using System;

namespace AddAndSubtract
{
    class Program
    {
        static void Main(string[] args)
        {
            int firstNum = int.Parse(Console.ReadLine());
            int secondNum = int.Parse(Console.ReadLine());
            int threeNum = int.Parse(Console.ReadLine());
            Console.WriteLine(SbstractNum(firstNum,secondNum,threeNum));
        }

        static int SumNum(int a, int b)
        {
            return a + b;
        }

        static int SbstractNum(int a, int b, int c)
        {
            return SumNum(a, b)-c;
        }
    }
}
