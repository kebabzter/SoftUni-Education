using System;
using System.Linq;

namespace IntersectionOfCircles
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] circleOne = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
            Circle c1 = new Circle(circleOne[0], circleOne[1],circleOne[2]);
            int[] circleTwo = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
            Circle c2 = new Circle(circleTwo[0], circleTwo[1], circleTwo[2]);
            double distance = CalcDistance(c1, c2);
            if (distance <= c1.Radius + c2.Radius )
            {
                Console.WriteLine("Yes");
            }
            else
            {
                Console.WriteLine("No");
            }

        }
        public static double CalcDistance(Circle c1, Circle c2)
        {
            int a = Math.Abs(c1.X - c2.X);
            int b = Math.Abs(c1.Y - c2.Y);
            double distance = Math.Sqrt(Math.Pow(a, 2) + Math.Pow(b, 2));
            return distance;
        }

    }

    class Circle
    {
        public int X { get; set; }
        public int Y { get; set; }
        public int Radius { get; set; }
        public Circle(int x,int y,int radius)
        {
            X = x;
            Y = y;
            Radius = radius;
        }
    }


}
