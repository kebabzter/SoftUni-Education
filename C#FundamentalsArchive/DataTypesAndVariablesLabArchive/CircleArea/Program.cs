using System;

namespace CircleArea
{
    class Program
    {
        static void Main(string[] args)
        {
            double radius = double.Parse(Console.ReadLine());
            Console.WriteLine($"{Math.PI*Math.Pow(radius,2):f12}");
        }
    }
}
