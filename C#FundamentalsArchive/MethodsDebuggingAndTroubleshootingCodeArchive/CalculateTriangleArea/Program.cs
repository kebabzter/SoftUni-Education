using System;

namespace CalculateTriangleArea
{
    class Program
    {
        static void Main(string[] args)
        {
            double width = double.Parse(Console.ReadLine());
            double height = double.Parse(Console.ReadLine());
            Console.WriteLine(Area(width, height));
        }
        static double Area(double a, double b)
        {
            return a * b/2;
        }
    }
}
