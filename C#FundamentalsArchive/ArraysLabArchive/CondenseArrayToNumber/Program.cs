using System;
using System.Linq;

namespace CondenseArrayToNumber
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] numbers = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
            while (numbers.Length>1)
            {
                int[] condense = new int[numbers.Length-1];
                for (int i = 0; i < numbers.Length-1; i++)
                {
                    condense[i] = numbers[i] + numbers[i+1];
                }
                numbers = condense;
            }
            Console.WriteLine(numbers[0]);
        }
    }
}
