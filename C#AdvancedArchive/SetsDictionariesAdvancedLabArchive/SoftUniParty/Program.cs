using System;
using System.Collections.Generic;

namespace SoftUniParty
{
    class Program
    {
        static void Main(string[] args)
        {
            HashSet<string> vip = new HashSet<string>();
            HashSet<string> regular = new HashSet<string>();
            while (true)
            {
                string input = Console.ReadLine();
                if (input == "PARTY")
                {
                    break;
                }
                if (char.IsDigit(input[0]))
                {
                    vip.Add(input);
                }
                else
                {
                    regular.Add(input);
                }
            }
            while (true)
            {
                string input = Console.ReadLine();
                if (input == "END")
                {
                    break;
                }
                if (char.IsDigit(input[0]))
                {
                    vip.Remove(input);
                }
                else
                {
                    regular.Remove(input);
                }
            }
            Console.WriteLine(vip.Count + regular.Count);
            foreach (var item in vip)
            {
                Console.WriteLine(item);
            }
            foreach (var item in regular)
            {
                Console.WriteLine(item);
            }

        }
    }
}
