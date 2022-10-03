using System;

namespace CakeIngredients
{
    class Program
    {
        static void Main(string[] args)
        {
            int count = 0;
            while (true)
            {
                string ingredient = Console.ReadLine();
                if (ingredient=="Bake!")
                {
                    break;
                }
                Console.WriteLine($"Adding ingredient {ingredient}.");
                count++;
            }
            Console.WriteLine($"Preparing cake with {count} ingredients.");
        }
    }
}
