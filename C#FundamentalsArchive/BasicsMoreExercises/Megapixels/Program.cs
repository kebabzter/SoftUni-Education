using System;

namespace Megapixels
{
    class Program
    {
        static void Main(string[] args)
        {
            int width = int.Parse(Console.ReadLine());
            int height = int.Parse(Console.ReadLine());
            double resolution =Math.Round(1.0*width/1000000* height,1);
            Console.WriteLine($"{width}x{height} => {resolution}MP");
        }
    }
}
