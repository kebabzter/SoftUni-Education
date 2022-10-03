using System;

namespace MathPower
{
    class Program
    {
        static void Main(string[] args)
        {
            double number = double.Parse(Console.ReadLine());
            int power = int.Parse(Console.ReadLine());
            Console.WriteLine(MathPower(number,power));
        }
        static double MathPower(double num, int pow)
        {
            return Math.Pow(num,pow);
        }
    }
}
