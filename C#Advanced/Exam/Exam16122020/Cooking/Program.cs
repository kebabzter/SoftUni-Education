using System;
using System.Collections.Generic;
using System.Linq;

namespace Cooking
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
            Queue<int> liquids = new Queue<int>(firstLine);
            Stack<int> ingredients = new Stack<int>(secondLine);
            int bread = 0;
            int cake = 0;
            int pastry = 0;
            int fruitPie = 0;
            while (liquids.Count>0 && ingredients.Count>0)
            {
                int sum = liquids.Peek() + ingredients.Peek();
                switch (sum)
                {
                    case 25:
                        bread++;
                        liquids.Dequeue();
                        ingredients.Pop();
                        break;
                    case 50:
                        cake++;
                        liquids.Dequeue();
                        ingredients.Pop();
                        break;
                    case 75:
                        pastry++;
                        liquids.Dequeue();
                        ingredients.Pop();
                        break;
                    case 100:
                        fruitPie++;
                        liquids.Dequeue();
                        ingredients.Pop();
                        break;
                    default:
                        liquids.Dequeue();
                        int ingredient = ingredients.Pop() + 3;
                        ingredients.Push(ingredient);
                        break;
                }
            }

            if (bread>=1&&cake>=1&&pastry>=1&&fruitPie>=1)
            {
                Console.WriteLine("Wohoo! You succeeded in cooking all the food!");
            }
            else
            {
                Console.WriteLine("Ugh, what a pity! You didn't have enough materials to cook everything.");
            }

            if (liquids.Count==0)
            {
                Console.WriteLine("Liquids left: none");
            }
            else
            {
                Console.WriteLine($"Liquids left: {string.Join(", ",liquids)}");
            }

            if (ingredients.Count == 0)
            {
                Console.WriteLine("Ingredients left: none");
            }
            else
            {
                Console.WriteLine($"Ingredients left: {string.Join(", ", ingredients)}");
            }

            Console.WriteLine($"Bread: {bread}");
            Console.WriteLine($"Cake: {cake}");
            Console.WriteLine($"Fruit Pie: {fruitPie}");
            Console.WriteLine($"Pastry: {pastry}");
        }
    }
}
