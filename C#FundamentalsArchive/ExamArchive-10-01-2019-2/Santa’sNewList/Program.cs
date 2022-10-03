using System;
using System.Collections.Generic;
using System.Linq;

namespace Santa_sNewList
{
    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, int> children = new Dictionary<string, int>();
            Dictionary<string, int> presents = new Dictionary<string, int>();

            while (true)
            {
                string input = Console.ReadLine();
                if (input=="END")
                {
                    break;
                }

                string[] info = input.Split("->",StringSplitOptions.RemoveEmptyEntries);
                if (info.Length==3)
                {
                    string childName = info[0];
                    string typeOfToy = info[1];
                    int amount = int.Parse(info[2]);
                    if (!children.ContainsKey(childName))
                    {
                        children.Add(childName, 0);
                    }
                    children[childName] += amount;

                    if (!presents.ContainsKey(typeOfToy))
                    {
                        presents.Add(typeOfToy,0);
                    }
                    presents[typeOfToy] += amount;
                }
                else if (info.Length==2)
                {
                    string childName = info[1];
                    if (children.ContainsKey(childName))
                    {
                        children.Remove(childName);
                    }
                }
            }

            Console.WriteLine("Children:");
            foreach (var item in children.OrderByDescending(x=>x.Value).ThenBy(x=>x.Key))
            {
                Console.WriteLine($"{item.Key} -> {item.Value}");
            }
            Console.WriteLine("Presents:");
            foreach (var item in presents)
            {
                Console.WriteLine($"{item.Key} -> {item.Value}");
            }
        }
    }
}
