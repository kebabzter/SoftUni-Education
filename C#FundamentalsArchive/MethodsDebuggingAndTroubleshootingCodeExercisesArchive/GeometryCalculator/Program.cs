using System;

namespace GeometryCalculator
{
    class Program
    {
        static void Main(string[] args)
        {
            string firure = Console.ReadLine().ToLower();
            double result = 0;
            switch (firure)
            {
                case "triangle":
                    double side = double.Parse(Console.ReadLine());
                    double height = double.Parse(Console.ReadLine());
                    result = Triangle(side,height);
                    break;
                case "square":
                    double sideSquare = double.Parse(Console.ReadLine());
                    result = Square(sideSquare);
                    break;
                case "rectangle":
                    double width = double.Parse(Console.ReadLine());
                    double heightRectangle = double.Parse(Console.ReadLine());
                    result = Rectangle(width,heightRectangle);
                    break;
                case "circle":
                    double radius = double.Parse(Console.ReadLine());
                    result = Circle(radius);
                    break;
            }
            Console.WriteLine($"{result:f2}");
        }

        private static double Circle(double radius)
        {
            return Math.PI*radius*radius;
        }

        private static double Rectangle(double width, double heightRectangle)
        {
            return width*heightRectangle;
        }

        private static double Square(double sideSquare)
        {
            return sideSquare*sideSquare;
        }

        private static double Triangle(double side, double height)
        {
            return side*height/2;
        }
    }
}
