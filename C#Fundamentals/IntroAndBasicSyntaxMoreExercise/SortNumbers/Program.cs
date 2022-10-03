using System;

namespace SortNumbers
{
    class Program
    {
        static void Main(string[] args)
        {
            int num1 = int.Parse(Console.ReadLine());
            int num2 = int.Parse(Console.ReadLine());
            int num3 = int.Parse(Console.ReadLine());
            int first = 0;
            int second = 0;
            int third = 0;
            if (num1 > num2 && num1 > num3)
            {
                first = num1;
                if (num2 > num3)
                {
                    second = num2;
                    third = num3;
                }
                else
                {
                    second = num3;
                    third = num2;
                }
            }
            else if (num2 > num1 && num2 > num3)
            {
                first = num2;
                if (num1 > num3)
                {
                    second = num1;
                    third = num3;
                }
                else
                {
                    second = num3;
                    third = num1;
                }
            }
            else
            {
                first = num3;
                if (num1 > num2)
                {
                    second = num1;
                    third = num2;
                }
                else
                {
                    second = num2;
                    third = num1;
                }
            }
            Console.WriteLine(first);
            Console.WriteLine(second);
            Console.WriteLine(third);
        }
    }
}
