using System;
using System.Linq;

namespace AppliedArithmetics
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] numbers = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();
            Action<int[]> printer = number => Console.WriteLine(string.Join(" ",number));
           
            while (true)
            {
                string commands = Console.ReadLine();
                if (commands=="end")
                {
                    break;
                }
                switch (commands)
                {
                    case "add":
                        numbers = ForEach(numbers, number => ++number);
                        break;
                    case "multiply":
                        numbers = ForEach(numbers, number => number*2);
                        break;
                    case "subtract":
                        numbers = ForEach(numbers, number => --number);
                        break;
                    case "print":
                        printer(numbers);
                        break;
                }
            }
        }

        public static int[] ForEach(int[] numbers, Func<int, int> func) 
            => numbers.Select(number => func(number)).ToArray();
    }
}
