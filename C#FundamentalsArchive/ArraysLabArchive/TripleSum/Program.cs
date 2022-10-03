using System;
using System.Linq;

namespace TripleSum
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] numbers = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
            bool flag = false;
            for (int i = 0; i < numbers.Length; i++)
            {
                for (int j = i+1; j < numbers.Length; j++)
                {
                    if (numbers.Contains(numbers[i] + numbers[j]))
                    {
                        Console.WriteLine($"{numbers[i]} + {numbers[j]} == {numbers[i]+numbers[j]}");
                        flag = true;
                    }
                }
            }
            if (!flag)
            {
                Console.WriteLine("No");
            }
        }
    }
}
