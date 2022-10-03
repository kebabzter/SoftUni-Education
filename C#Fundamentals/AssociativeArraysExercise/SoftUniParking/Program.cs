using System;
using System.Collections.Generic;

namespace SoftUniParking
{
    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, string> parking = new Dictionary<string, string>();
            int n = int.Parse(Console.ReadLine());
            for (int i = 0; i < n; i++)
            {
                string[] input = Console.ReadLine()
                    .Split(" ",StringSplitOptions.RemoveEmptyEntries);
                string command = input[0];
                string user = input[1];
                
                switch (command)
                {
                    case "register":
                        string number = input[2];
                        if (parking.ContainsKey(user))
                        {
                            Console.WriteLine($"ERROR: already registered with plate number {parking[user]}");
                        }
                        else
                        {
                            parking.Add(user,number);
                            Console.WriteLine($"{user} registered {number} successfully");
                        }
                        break;

                    case "unregister":
                        if (parking.ContainsKey(user))
                        {
                            parking.Remove(user);
                            Console.WriteLine($"{user} unregistered successfully");
                        }
                        else
                        {
                            Console.WriteLine($"ERROR: user {user} not found");
                        }
                        break;
                }
            }

            foreach (var item in parking)
            {
                Console.WriteLine($"{item.Key} => {item.Value}");
            }
        }
    }
}
