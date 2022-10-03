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
            bool flag = false;
            while (true)
            {
                string input = Console.ReadLine();
                if (input == "END")
                {
                    break;
                }
                if (input == "PARTY")
                {
                    flag = true;
                    continue;
                }
                if (flag)
                {
                    if (isVip(input))
                    {
                        vip.Remove(input);
                    }
                    else
                    {
                        regular.Remove(input);
                    }
                }
                else
                {
                    if (isVip(input))
                    {
                        vip.Add(input);
                    }
                    else
                    {
                        regular.Add(input);
                    }
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

        private static bool isVip(string number)
        {
            return char.IsDigit(number[0]);
        }
    }
}
