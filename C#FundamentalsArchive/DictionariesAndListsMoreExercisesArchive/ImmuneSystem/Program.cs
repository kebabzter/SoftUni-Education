using System;
using System.Collections.Generic;

namespace ImmuneSystem
{
    class Program
    {
        static void Main(string[] args)
        {
            int initialHealth = int.Parse(Console.ReadLine());
            int remainingHealth = initialHealth;
            List<string> virusNames = new List<string>();
            while (true)
            {
                string input = Console.ReadLine();
                if (input=="end")
                {
                    break;
                }
                int sumSymbol = 0;
                for (int i = 0; i < input.Length; i++)
                {
                    sumSymbol += (int)input[i];
                }
                int strength = sumSymbol / 3;
                int defeat = 0;
                if (virusNames.Contains(input))
                {
                    defeat = strength * input.Length/3;
                }
                else
                {
                    virusNames.Add(input);
                    defeat = strength * input.Length;
                }
                int defeatMins=defeat/60;
                int defeatSecs=defeat%60;
                remainingHealth -= defeat;
                Console.WriteLine($"Virus {input}: {strength} => {defeat} seconds");
                if (remainingHealth>0)
                {
                    Console.WriteLine($"{input} defeated in {defeatMins}m {defeatSecs}s.");
                    Console.WriteLine($"Remaining health: {remainingHealth}");
                    remainingHealth +=(int)(remainingHealth * 0.2);
                    if (remainingHealth>initialHealth)
                    {
                        remainingHealth = initialHealth;
                    }
                }
                else
                {
                    break;
                }
            }
            if (remainingHealth > 0)
            {
                Console.WriteLine($"Final Health: {remainingHealth}");
            }
            else
            {
                Console.WriteLine("Immune System Defeated.");
            }
        }
    }
}
