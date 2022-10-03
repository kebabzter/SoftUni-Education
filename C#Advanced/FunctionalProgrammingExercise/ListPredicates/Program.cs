using System;
using System.Linq;

namespace ListPredicates
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            int[] numbers = Console.ReadLine()
               .Split(" ", StringSplitOptions.RemoveEmptyEntries)
               .Select(int.Parse)
               .ToArray();

            if (n<=0)
            {
                return;
            }

            Func<int[], int, bool> filter = (allNumbers, number) =>
                {
                    bool divisible = true;
                    for (int i = 0; i < allNumbers.Length; i++)
                    {
                        if (number % allNumbers[i] != 0)
                        {
                            divisible = false;
                            break;
                        }
                    }
                    return divisible;
                };
            int[] divisibleNumbers = Enumerable.Range(1,n)
                .Where(number=>filter(numbers,number)).ToArray();

            Console.WriteLine(string.Join(" ",divisibleNumbers));
        }
    }
}
