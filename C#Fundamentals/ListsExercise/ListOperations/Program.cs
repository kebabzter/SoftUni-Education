using System;
using System.Collections.Generic;
using System.Linq;

namespace ListOperations
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
                if (input == "End")
                {
                    break;
                }

                string[] commands = input.Split(" ",StringSplitOptions.RemoveEmptyEntries);
                string command = commands[0];
                switch (command)
                {
                    case "Add":
                        numbers.Add(int.Parse(commands[1]));
                        break;
                    case "Insert":
                        int number = int.Parse(commands[1]);
                        int index = int.Parse(commands[2]);
                        if (IsValid(numbers,index))
                        {
                            numbers.Insert(index,number);
                        }
                        else
                        {
                            Console.WriteLine("Invalid index");
                        }
                        break;
                    case "Remove":
                        int indexRemove = int.Parse(commands[1]);
                        if (IsValid(numbers, indexRemove))
                        {
                            numbers.RemoveAt(indexRemove);
                        }
                        else
                        {
                            Console.WriteLine("Invalid index");
                        }
                        break;
                    case "Shift":
                        string direction = commands[1];
                        int count = int.Parse(commands[2]);
                        if (direction=="left")
                        {
                            for (int i = 0; i <count; i++)
                            {
                                numbers.Add(numbers[0]);
                                numbers.RemoveAt(0);
                            }
                        }
                        else if (direction=="right")
                        {
                            for (int i = 0; i < count; i++)
                            {
                                numbers.Insert(0,numbers[numbers.Count-1]);
                                numbers.RemoveAt(numbers.Count - 1);
                            }
                        }
                        break;
                }
            }
            Console.WriteLine(string.Join(" ",numbers));
        }
        static bool IsValid(List<int> num,int index)
        {
            if (index>=0 && index<num.Count)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
