using System;

namespace MathPower
{
    class Program
    {
        static void Main(string[] args)
        {
            double number = double.Parse(Console.ReadLine());
            int power = int.Parse(Console.ReadLine());
            double result = MathPow(number,power);
            Console.WriteLine(result);
        }

        static double MathPow(double num,int pow)
        {
            return Math.Pow(num, pow);
        }
    }
}
