using System;
using System.Collections.Generic;
using System.Linq;

namespace BombNumbers
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> numbers = Console.ReadLine()
               .Split(" ", StringSplitOptions.RemoveEmptyEntries)
               .Select(int.Parse)
               .ToList();

            int[] bombNumber = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();
            int bomb = bombNumber[0];
            int power = bombNumber[1];
            while (true)
            {
                int indexBomb = numbers.IndexOf(bomb);
                if (indexBomb==-1)
                {
                    break;
                }

                int startIndex = indexBomb - power;
                if (startIndex<0)
                {
                    startIndex = 0;
                }

                int endIndex = indexBomb + power;
                if (endIndex>numbers.Count)
                {
                    endIndex = numbers.Count - 1;
                }

                numbers.RemoveRange(startIndex, endIndex - startIndex+1);
            }
            Console.WriteLine(numbers.Sum());
        }
    }
}
