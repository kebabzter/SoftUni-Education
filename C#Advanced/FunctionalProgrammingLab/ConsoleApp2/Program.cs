using System;

namespace ConsoleApp2
{
    class Program
    {
        static void Main(string[] args)
        {
            Func<int, int, int> sum = (a, b) => a + b;
            Func<int, int, int> multiply = (a, b) => a * b;

            Console.WriteLine(Calculate(3, 5, sum));
            Console.WriteLine(Calculate(3, 5, multiply));
            Console.WriteLine(sum(4,3));
        }

        private static int Calculate(int a, int b, Func<int, int, int> operation)
        {
            return operation(a, b);
        }
    }
}
