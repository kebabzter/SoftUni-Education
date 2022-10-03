using System;

namespace TribonacciSequence
{
    class Program
    {
        static void Main(string[] args)
        {
            int number= int.Parse(Console.ReadLine());
            Tribonacci(number);
        }

        static void Tribonacci(int num)
        {
            if (num == 1)
            {
                Console.WriteLine("1");
            }
            else if (num == 2)
            {
                Console.WriteLine("1 1");
            }
            else if (num == 3)
            {
                Console.WriteLine("1 1 2");
            }
            else
            {
                int x = 1;
                int y = 1;
                int z = 2;
                int sum = 0;
                Console.Write("1 1 2 ");
                for (int i = 0; i < num - 3; i++)
                {
                    sum = x + y + z;
                    Console.Write(sum + " ");
                    x = y;
                    y = z;
                    z = sum;
                }
            }
        }
    }
}
