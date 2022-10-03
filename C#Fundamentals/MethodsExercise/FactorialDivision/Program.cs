using System;

namespace FactorialDivision
{
    class Program
    {
        static void Main(string[] args)
        {
            int firstNum = int.Parse(Console.ReadLine());
            int secondNum = int.Parse(Console.ReadLine());
            double divide = (double)Factorial(firstNum) / Factorial(secondNum);
            Console.WriteLine($"{divide:f2}");
        }

        static long Factorial(int number)
        {
            if (number==1)
            {
                return 1;
            }
            else
            {
                return number*Factorial(number - 1);
            }
        }
    }
}
