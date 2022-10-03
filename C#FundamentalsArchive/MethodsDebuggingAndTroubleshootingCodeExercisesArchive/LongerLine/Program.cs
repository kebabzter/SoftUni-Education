using System;

namespace LongerLine
{
    class Program
    {
        static void Main(string[] args)
        {
            double x1 = double.Parse(Console.ReadLine());
            double y1 = double.Parse(Console.ReadLine());
            double x2 = double.Parse(Console.ReadLine());
            double y2 = double.Parse(Console.ReadLine());
            double x3 = double.Parse(Console.ReadLine());
            double y3 = double.Parse(Console.ReadLine());
            double x4 = double.Parse(Console.ReadLine());
            double y4 = double.Parse(Console.ReadLine());
            LongLine(x1, y1, x2, y2, x3, y3, x4, y4);
        }

        static void Center(double x1, double y1, double x2, double y2)
        {
            double t1 = Math.Abs(x1) + Math.Abs(y1);
            double t2 = Math.Abs(x2) + Math.Abs(y2);
            if (t1 > t2)
            {
                Console.Write($"({x2}, {y2})");
                Console.WriteLine($"({x1}, {y1})");
            }
            else
            {
                Console.Write($"({x1}, {y1})");
                Console.Write($"({x2}, {y2})");
            }
        }
        static void LongLine(double x1, double y1, double x2, double y2, double x3, double y3, double x4, double y4)
        {
            double rx1 = Math.Pow(x1 - x2, 2);
            double ry1 = Math.Pow(y1 - y2, 2);
            double rx2 = Math.Pow(x3 - x4, 2);
            double ry2 = Math.Pow(y3 - y4, 2);
            double dist1 = Math.Sqrt(rx1 + ry1);
            double dist2 = Math.Sqrt(rx2 + ry2);
            if (dist1 > dist2)
            {
                Center(x1, y1, x2, y2);
            }
            else
            {
                Center(x3, y3, x4, y4);
            }
        }
    }
}
