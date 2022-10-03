using System;
using System.Collections.Generic;
using System.Linq;

namespace ListManipulationAdvanced
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> numbers = Console.ReadLine()
               .Split(" ", StringSplitOptions.RemoveEmptyEntries)
               .Select(int.Parse)
               .ToList();
            bool flag = false;
            while (true)
            {
                string[] input = Console.ReadLine()
                    .Split(" ", StringSplitOptions.RemoveEmptyEntries);
                if (input[0] == "end")
                {
                    break;
                }

                string command = input[0];
                switch (command)
                {
                    case "Add":
                        int numberAdd = int.Parse(input[1]);
                        numbers.Add(numberAdd);
                        flag = true;
                        break;
                    case "Remove":
                        int numberRemove = int.Parse(input[1]);
                        numbers.Remove(numberRemove);
                        flag = true;
                        break;
                    case "RemoveAt":
                        int indexRemove = int.Parse(input[1]);
                        numbers.RemoveAt(indexRemove);
                        flag = true;
                        break;
                    case "Insert":
                        int numberInsert = int.Parse(input[1]);
                        int indexInsert = int.Parse(input[2]);
                        numbers.Insert(indexInsert, numberInsert);
                        flag = true;
                        break;
                    case "Contains":
                        int numberContains = int.Parse(input[1]);
                        if (numbers.Contains(numberContains))
                        {
                            Console.WriteLine("Yes");
                        }
                        else
                        {
                            Console.WriteLine("No such number");
                        }
                        break;
                    case "PrintEven":
                        Console.WriteLine(string.Join(" ",numbers.Where(x=>x%2==0)));
                        break;
                    case "PrintOdd":
                        Console.WriteLine(string.Join(" ", numbers.Where(x => x % 2 != 0)));
                        break;
                    case "GetSum":
                        Console.WriteLine(numbers.Sum());
                        break;
                    case "Filter":
                        string condition = input[1];
                        int numberFilter = int.Parse(input[2]);
                        if (condition=="<")
                        {
                            Console.WriteLine(string.Join(" ", numbers.Where(x => x < numberFilter)));
                        }
                        else if (condition==">")
                        {
                            Console.WriteLine(string.Join(" ", numbers.Where(x => x > numberFilter)));
                        }
                        else if (condition == ">=")
                        {
                            Console.WriteLine(string.Join(" ", numbers.Where(x => x >= numberFilter)));
                        }
                        else if (condition == "<=")
                        {
                            Console.WriteLine(string.Join(" ", numbers.Where(x => x <= numberFilter)));
                        }
                        break;
                }
            }
            if (flag)
            {
                Console.WriteLine(string.Join(" ", numbers));
            }
            
        }
    }
}
