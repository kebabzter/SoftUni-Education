using System;

namespace MathOperations
{
    class Program
    {
        static void Main(string[] args)
        {
            int num1 = int.Parse(Console.ReadLine());
            string command = Console.ReadLine();
            int num2 = int.Parse(Console.ReadLine());
            Console.WriteLine(Calculate(num1, command, num2));
        }

        static int Calculate(int a, string command, int b)
        {
            int result = 0;
            switch (command)
            {
                case "/":
                    result = a / b;
                    break;
                case "*":
                    result = a * b;
                    break;
                case "+":
                    result = a + b;
                    break;
                case "-":
                    result = a - b;
                    break;
            }
            return result;
        }
    }
}
