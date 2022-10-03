using System;

namespace NeighbourWars
{
    class Program
    {
        static void Main(string[] args)
        {
            int peshoDamage = int.Parse(Console.ReadLine());
            int goshoDamage = int.Parse(Console.ReadLine());
            int peshoHealth = 100;
            int goshoHealth = 100;
            int round = 0;
            while (true)
            {
                round++;
                if (round%2==0)
                {
                    peshoHealth -= goshoDamage;
                    if (peshoHealth<=0)
                    {
                        Console.WriteLine($"Gosho won in {round}th round.");
                        break;
                    }
                    else
                    {
                        Console.WriteLine($"Gosho used Thunderous fist and reduced Pesho to {peshoHealth} health.");
                    }
                }
                else
                {
                    goshoHealth -= peshoDamage;
                    if (goshoHealth<=0)
                    {
                        Console.WriteLine($"Pesho won in {round}th round.");
                        break;
                    }
                    else
                    {
                        Console.WriteLine($"Pesho used Roundhouse kick and reduced Gosho to {goshoHealth} health.");
                    }
                }
                if (round%3==0)
                {
                    peshoHealth += 10;
                    goshoHealth += 10;
                }
            }
        }
    }
}
