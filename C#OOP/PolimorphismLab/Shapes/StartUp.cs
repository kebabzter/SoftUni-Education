using System;

namespace Shapes
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            Rectangle rec = new Rectangle(3,4);
            Console.WriteLine(rec.CalculateArea());
            Console.WriteLine(rec.CalculatePerimeter());
            Console.WriteLine(rec.Draw());
            Circle circle = new Circle(2);
            Console.WriteLine(circle.CalculateArea());
            Console.WriteLine(circle.CalculatePerimeter());
            Console.WriteLine(circle.Draw());
        }
    }
}
