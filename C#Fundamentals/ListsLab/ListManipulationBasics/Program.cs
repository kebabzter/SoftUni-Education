using System;
using System.Collections.Generic;
using System.Linq;

namespace ListManipulationBasics
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
                string[] input = Console.ReadLine()
                    .Split(" ",StringSplitOptions.RemoveEmptyEntries);
                if (input[0]=="end")
                {
                    break;
                }

                string command = input[0];
                switch (command)
                {
                    case "Add":
                        int numberAdd = int.Parse(input[1]);
                        numbers.Add(numberAdd);
                        break;
                    case "Remove":
                        int numberRemove = int.Parse(input[1]);
                        numbers.Remove(numberRemove);
                        break;
                    case "RemoveAt":
                        int indexRemove= int.Parse(input[1]);
                        numbers.RemoveAt(indexRemove);
                        break;
                    case "Insert":
                        int numberInsert = int.Parse(input[1]);
                        int indexInsert = int.Parse(input[2]);
                        numbers.Insert(indexInsert, numberInsert);
                        break;
                }
            }
            Console.WriteLine(string.Join(" ",numbers));
        }
    }
}
