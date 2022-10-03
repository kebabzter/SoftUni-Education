using System;
using System.Linq;

namespace DistanceBetweenPoints
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] pointOne = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
            int[] pointTwo = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
            Point p1 = new Point(pointOne[0],pointOne[1]);
            Point p2 = new Point(pointTwo[0], pointTwo[1]);
            Console.WriteLine($"{CalcDistance(p1,p2):f3}");
        }
        public static double CalcDistance(Point p1,Point p2)
        {
            int a = Math.Abs(p1.X-p2.X);
            int b = Math.Abs(p1.Y-p2.Y);
            double distance = Math.Sqrt(Math.Pow(a,2)+Math.Pow(b,2));
            return distance;
        }
    }
    class Point
    {
        public int X { get; set; }
        public int Y { get; set; }

        public Point(int x,int y)
        {
            X = x;
            Y = y;
        }

    }
}
