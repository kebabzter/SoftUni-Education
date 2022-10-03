using System;
using System.Collections.Generic;
using System.Linq;

namespace HeartDelivery
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> listNumber = Console.ReadLine()
                .Split("@", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse).ToList();
            int lengthJump = 0;
            int takeValue = 0;
            int lastIndex = 0;
            int decrease = 0;
            int counterSuccess = 0;
            string command = Console.ReadLine();
            while (command != "Love!")
            {
                string[] input = command.Split(" ", StringSplitOptions.RemoveEmptyEntries).ToArray();
                lengthJump += int.Parse(input[1]);
                if (listNumber.Count <= lengthJump)
                {
                    lengthJump = 0;
                    var take = listNumber.GetRange(lengthJump, 1);
                    takeValue = take[0];
                    lastIndex = lengthJump;
                }
                else
                {
                    var take = listNumber.GetRange(lengthJump, 1);
                    takeValue = take[0];
                    lastIndex = lengthJump;
                }
                if (takeValue == 0)
                {
                    Console.WriteLine($"Place {lastIndex} already had Valentine's day.");
                    command = Console.ReadLine();
                    continue;
                }
                decrease = takeValue - 2;
                listNumber.RemoveAt(lastIndex);
                listNumber.Insert(lastIndex, decrease);
                if (decrease == 0)
                {
                    counterSuccess++;
                    Console.WriteLine($"Place {lastIndex} has Valentine's day.");
                }
                command = Console.ReadLine();
            }
            Console.WriteLine($"Cupid's last position was {lastIndex}.");
            if (counterSuccess == listNumber.Count)
            {
                Console.WriteLine($"Mission was successful.");
            }
            else
            {
                Console.WriteLine($"Cupid has failed {listNumber.Count - counterSuccess} places.");
            }

        }
    }
}
