using System;

namespace MultiplicationTable2
{
    class Program
    {
        static void Main(string[] args)
        {
            byte numberOne = byte.Parse(Console.ReadLine());
            byte numberTwo = byte.Parse(Console.ReadLine());
            if (numberTwo <= 10)
            {
                for (int i = numberTwo; i <= 10; i++)
                {
                    Console.WriteLine($"{numberOne} X {i} = {numberOne * i}");
                }
            }
            else
            {
                Console.WriteLine($"{numberOne} X {numberTwo} = {numberOne * numberTwo}");
            }
        }
    }
}
