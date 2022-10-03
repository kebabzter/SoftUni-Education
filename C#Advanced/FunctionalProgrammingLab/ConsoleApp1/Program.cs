using System;

namespace ConsoleApp1
{
    class Program
    {
        public delegate int Calculator(int a, int b);
        static void Main(string[] args)
        {
            Calculator sum = (a, b) => a + b;
            Calculator multiply = (a, b) => a * b;

            Console.WriteLine(Calculate(3,5,sum));
            Console.WriteLine(Calculate(3,5,multiply));
        }

        private static int Calculate(int a, int b, Calculator operation)
        {
            return operation(a,b);
        }
    }
}
