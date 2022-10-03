using System;
using System.Collections.Generic;
using System.Linq;

namespace Masterchef
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] firstLine = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();
            int[] secondLine = Console.ReadLine()
               .Split(" ", StringSplitOptions.RemoveEmptyEntries)
               .Select(int.Parse)
               .ToArray();
            Queue<int> ingredients = new Queue<int>(firstLine);
            Stack<int> freshness = new Stack<int>(secondLine);

            // Dipping sauce   150
            //Green salad 250
            //Chocolate cake  300
            //Lobster 400

            int dippingSauce = 0;
            int greenSalad = 0;
            int chocolateCake = 0;
            int lobster = 0;

            while (ingredients.Count>0 && freshness.Count>0)
            {
                int ingredient = ingredients.Peek();
                int freshnes = freshness.Peek();

                if (ingredient==0)
                {
                    ingredients.Dequeue();
                    continue;
                }
                int multiplication = ingredient * freshnes;

                switch (multiplication)
                {
                    case 150:
                        dippingSauce++;
                        ingredients.Dequeue();
                        freshness.Pop();
                        break;
                    case 250:
                        greenSalad++;
                        ingredients.Dequeue();
                        freshness.Pop();
                        break;
                    case 300:
                        chocolateCake++;
                        ingredients.Dequeue();
                        freshness.Pop();
                        break;
                    case 400:
                        lobster++;
                        ingredients.Dequeue();
                        freshness.Pop();
                        break;
                    default:
                        freshness.Pop();
                        int ingredientAdd = ingredients.Dequeue() + 5;
                        ingredients.Enqueue(ingredientAdd);
                        break;

                }
            }

            if (dippingSauce >= 1 && greenSalad >= 1 && chocolateCake >= 1 && lobster >= 1)
            {
                Console.WriteLine("Applause! The judges are fascinated by your dishes!");
            }
            else
            {
                Console.WriteLine("You were voted off. Better luck next year.");
            }

            if (ingredients.Count>0)
            {
                Console.WriteLine($"Ingredients left: {ingredients.Sum()}");
            }

            if (chocolateCake>=1)
            {
                Console.WriteLine($"# Chocolate cake --> {chocolateCake}");
            }

            if (dippingSauce>=1)
            {
                Console.WriteLine($"# Dipping sauce --> {dippingSauce}");
            }

            if (greenSalad>=1)
            {
                Console.WriteLine($"# Green salad --> {greenSalad}");
            }

            if (lobster>=1)
            {
                Console.WriteLine($"# Lobster --> {lobster}");
            }
        }
    }
}
