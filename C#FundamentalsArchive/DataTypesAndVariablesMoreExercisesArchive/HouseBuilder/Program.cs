using System;

namespace HouseBuilder
{
    class Program
    {
        static void Main(string[] args)
        {
            int num1 = int.Parse(Console.ReadLine());
            int num2 = int.Parse(Console.ReadLine());
            Console.WriteLine(4 * Math.Min(num1, num2) + (long)10 *Math.Max(num1, num2));
        }
    }
}
