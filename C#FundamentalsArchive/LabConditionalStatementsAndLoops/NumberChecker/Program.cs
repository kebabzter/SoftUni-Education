using System;

namespace NumberChecker
{
    class Program
    {
        static void Main(string[] args)
        {
            string number = Console.ReadLine();
            bool flag = true;
            for (int i = 0; i < number.Length; i++)
            {
                if (!char.IsDigit(number[i]))
                {
                    flag = false;
                    break;
                }
            }
            if (flag)
            {
                Console.WriteLine("It is a number.");
            }
            else
            {
                Console.WriteLine("Invalid input!");
            }
        }
    }
}
