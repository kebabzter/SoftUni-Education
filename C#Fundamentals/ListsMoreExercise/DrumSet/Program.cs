using System;
using System.Collections.Generic;
using System.Linq;

namespace DrumSet
{
    class Program
    {
        static void Main(string[] args)
        {
            double savings = double.Parse(Console.ReadLine());
            List<int> initialQuality = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToList();
            List<int> currentQuality = new List<int>();
            foreach (var item in initialQuality)
            {
                currentQuality.Add(item);
            }
            while (true)
            {
                string input = Console.ReadLine();
                if (input== "Hit it again, Gabsy!")
                {
                    break;
                }
                int power = int.Parse(input);
                for (int i = 0; i < currentQuality.Count; i++)
                {
                    if (currentQuality[i]-power<=0)
                    {
                        currentQuality[i] = initialQuality[i];
                        double price = currentQuality[i] * 3;
                        if (savings-price<=0)
                        {
                            currentQuality.RemoveAt(i);
                            initialQuality.RemoveAt(i);
                            i--;
                        }
                        else
                        {
                            savings -= price;
                        }
                    }
                    else
                    {
                        currentQuality[i] -= power;
                    }
                }
            }
            Console.WriteLine(string.Join(" ",currentQuality));
            Console.WriteLine($"Gabsy has {savings:f2}lv.");
        }
    }
}
