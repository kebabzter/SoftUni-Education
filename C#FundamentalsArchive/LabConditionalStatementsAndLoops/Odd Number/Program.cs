using System;

namespace Odd_Number
{
    class Program
    {
        static void Main(string[] args)
        {
            int number= int.Parse(Console.ReadLine());
            byte count = 0;
            while (number%2==0)
            {
                count++;
                if (count == 10)
                {
                    break;
                }
                Console.WriteLine("Please write an odd number.");
                number = int.Parse(Console.ReadLine());
            }
            if (count!=10)
            {
                Console.WriteLine($"The number is: {Math.Abs(number)}");
            }  
        }
    }
}
