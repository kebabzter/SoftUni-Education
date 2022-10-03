using System;

namespace TrainingHallEquipment
{
    class Program
    {
        static void Main(string[] args)
        {
            double budget = double.Parse(Console.ReadLine());
            int numbers = int.Parse(Console.ReadLine());
            double sum = 0;
            for (int i = 0; i < numbers; i++)
            {
                string name = Console.ReadLine();
                double price = double.Parse(Console.ReadLine());
                int count = int.Parse(Console.ReadLine());
                if (count>1)
                {
                    name = name + "s";
                }
                Console.WriteLine($"Adding {count} {name} to cart.");
                sum += price*count;
            }
            Console.WriteLine($"Subtotal: ${sum:f2}");
            if (budget>sum)
            {
                Console.WriteLine($"Money left: ${budget-sum:f2}");
            }
            else
            {
                Console.WriteLine($"Not enough. We need ${sum-budget:f2} more.");
            }
        }
    }
}
