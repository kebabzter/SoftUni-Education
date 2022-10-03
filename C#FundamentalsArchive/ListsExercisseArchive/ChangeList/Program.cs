using System;
using System.Collections.Generic;
using System.Linq;

namespace ChangeList
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> numbers = Console.ReadLine()
              .Split(" ", StringSplitOptions.RemoveEmptyEntries)
              .Select(int.Parse)
              .ToList();
            string input = string.Empty;
            while (true)
            {
                input = Console.ReadLine();
                if (input == "Odd" || input=="Even")
                {
                    break;
                }

                string[] inputArr = input.Split(" ", StringSplitOptions.RemoveEmptyEntries);
                int element = int.Parse(inputArr[1]);
                if (inputArr[0] == "Delete")
                {
                    numbers.RemoveAll(x => x == element);
                }
                else if (inputArr[0] == "Insert")
                {
                    int position = int.Parse(inputArr[2]);
                    numbers.Insert(position, element);
                }
            }
            if (input=="Odd")
            {
                Console.WriteLine(string.Join(" ", numbers.Where(x => x % 2 != 0)));
            }
            else
            {
                Console.WriteLine(string.Join(" ", numbers.Where(x => x % 2 == 0)));
            }
        }
    }
}
