using System;
using System.Collections.Generic;
using System.Linq;

namespace MuOnline
{
    class Program
    {
        static void Main(string[] args)
        {
            List<string> rooms = Console.ReadLine().Split("|").ToList();
            int health = 100;
            int bitcoins = 0;
            int currHealth = 0;
            int tempHealth = 0;
            bool flag = false;
            for (int i = 0; i < rooms.Count; i++)
            {
                int currBitcoins = 0;
                string[] element = rooms[i].Split(" ");
                string command = element[0];
                int number = int.Parse(element[1]);

                switch (command)
                {
                    case "potion":
                        currHealth = health;
                        tempHealth = health;
                        currHealth += number;
                        if (currHealth <= 100)
                        {
                            health += number;
                            Console.WriteLine($"You healed for {number} hp.");
                            Console.WriteLine($"Current health: {health} hp.");
                        }
                        else if (currHealth > 100)
                        {
                            int diff = 100 - tempHealth;
                            health = 100;
                            Console.WriteLine($"You healed for {diff} hp.");
                            Console.WriteLine($"Current health: {health} hp.");
                        }
                        break;
                    case "chest":
                        bitcoins += number;
                        currBitcoins += number;
                        Console.WriteLine($"You found {currBitcoins} bitcoins.");
                        break;
                    default:
                        health -= number;
                        if (health <= 0)
                        {
                            Console.WriteLine($"You died! Killed by {command}.");
                            Console.WriteLine($"Best room: {i + 1}");
                            flag = true;
                        }
                        else
                        {
                            Console.WriteLine($"You slayed {command}.");
                        }
                        break;
                }
                if (flag)
                {
                    break;
                }
            }
            if (!flag)
            {
                Console.WriteLine("You've made it!");
                Console.WriteLine($"Bitcoins: {bitcoins}");
                Console.WriteLine($"Health: {health}");
            }
        }
    }
}
