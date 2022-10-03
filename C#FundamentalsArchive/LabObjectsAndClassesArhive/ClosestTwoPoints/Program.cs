using System;
using System.Linq;

namespace ClosestTwoPoints
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            Point[] points = new Point[n];
            for (int i = 0; i < n; i++)
            {
                int[] currentPoint = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
                Point p = new Point(currentPoint[0], currentPoint[1]);
                points[i] = p;
            }
            Point[] minDistancePoint=FindClosestPoints(points);
            Console.WriteLine($"{CalcDistance(minDistancePoint[0], minDistancePoint[1]):f3}");
            foreach (var item in minDistancePoint)
            {
                Console.WriteLine($"({item.X}, {item.Y})");
            }
        }

        public static double CalcDistance(Point p1, Point p2)
        {
            int a = Math.Abs(p1.X - p2.X);
            int b = Math.Abs(p1.Y - p2.Y);
            double distance = Math.Sqrt(Math.Pow(a, 2) + Math.Pow(b, 2));
            return distance;
        }
        public static Point[] FindClosestPoints(Point[] points)
        {
            Point[] result = new Point[2];
            double minDistance = double.MaxValue;
            for (int i = 0; i < points.Length-1; i++)
            {
                for (int j = i+1; j < points.Length; j++)
                {
                    double currentDistance = CalcDistance(points[i], points[j]);
                    if (currentDistance<minDistance)
                    {
                        minDistance = currentDistance;
                        result[0] = points[i];
                        result[1] = points[j];
                    }
                }
            }
            return result;
        }
    }
    class Point
    {
        public int X { get; set; }
        public int Y { get; set; }

        public Point(int x, int y)
        {
            X = x;
            Y = y;
        }

    }
}
