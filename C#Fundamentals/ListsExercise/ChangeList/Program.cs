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

            while (true)
            {
                string input = Console.ReadLine();
                if (input == "end")
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
            Console.WriteLine(string.Join(" ", numbers));
        }
    }
}
