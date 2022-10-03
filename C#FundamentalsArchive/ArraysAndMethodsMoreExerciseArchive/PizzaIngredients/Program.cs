using System;

namespace PizzaIngredients
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] ingredients = Console.ReadLine()
                 .Split(" ", StringSplitOptions.RemoveEmptyEntries);
            int length = int.Parse(Console.ReadLine());
            int count = -1;
            string[] result = new string[10];
            for (int i = 0; i < ingredients.Length; i++)
            {
                if (ingredients[i].Length==length)
                {
                    count++;
                    if (count<=9)
                    {
                        result[count] = ingredients[i];
                        Console.WriteLine($"Adding {ingredients[i]}.");
                    }
                    else
                    {
                        count--;
                        break;
                    }
                }
            }
            Console.WriteLine($"Made pizza with total of {count+1} ingredients.");
            Console.Write("The ingredients are: ");
            for (int i = 0; i <= count; i++)
            {
                if (i!=count)
                {
                    Console.Write($"{result[i]}, ");
                }
                else
                {
                    Console.Write($"{result[i]}.");
                }
            }
        }
    }
}
