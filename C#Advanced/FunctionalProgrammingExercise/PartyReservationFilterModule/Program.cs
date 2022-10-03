using System;
using System.Collections.Generic;
using System.Linq;

namespace PartyReservationFilterModule
{
    class Program
    {
        static void Main(string[] args)
        {
            List<string> guest = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .ToList();
            List<string> filters = new List<string>();
            string input = Console.ReadLine();
            while (input!="Print")
            {
                var commands = input.Split(";", StringSplitOptions.RemoveEmptyEntries);
                if (commands[0]=="Add filter")
                {
                    filters.Add(commands[1]+" "+commands[2]);
                }
                else if (commands[0]=="Remove filter")
                {
                    filters.Remove(commands[1] + " " + commands[2]);
                }
                
                input = Console.ReadLine();
            }

            foreach (var item in filters)
            {
                var command = item.Split(" ",StringSplitOptions.RemoveEmptyEntries);
                if (command[0]=="Starts")
                {
                    guest = guest.Where(x=>!x.StartsWith(command[2])).ToList();
                }
                else if (command[0]=="Ends")
                {
                    guest = guest.Where(x => !x.EndsWith(command[2])).ToList();
                }
                else if (command[0]=="Length")
                {
                    guest = guest.Where(x => x.Length!=int.Parse(command[1])).ToList();
                }
                else if (command[0]=="Contains")
                {
                    guest = guest.Where(x => !x.Contains(command[1])).ToList();
                }
            }
            if (guest.Any())
            {
                Console.WriteLine(string.Join(" ",guest));
            }
        }
    }
}
