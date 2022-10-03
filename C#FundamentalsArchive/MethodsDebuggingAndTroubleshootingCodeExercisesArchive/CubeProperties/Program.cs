using System;

namespace CubeProperties
{
    class Program
    {
        static void Main(string[] args)
        {
            double side = double.Parse(Console.ReadLine());
            string parameter = Console.ReadLine();
            double result = 0;
            switch (parameter)
            {
                case "face":
                    result = GetFace(side);
                    break;
                case "space":
                    result = GetSpace(side);
                    break;
                case "volume":
                    result = GetVolume(side);
                    break;
                case "area":
                    result = GetArea(side);
                    break;
            }
            Console.WriteLine($"{result:f2}");
        }

        private static double GetArea(double side)
        {
            return 6*side*side;
        }

        private static double GetVolume(double side)
        {
            return side*side*side;
        }

        private static double GetSpace(double side)
        {
            return Math.Sqrt(3 * side * side);
        }

        private static double GetFace(double side)
        {
           return Math.Sqrt(2*side*side);
        }
    }
}
