using System;

namespace CaloriesCounter
{
    class Program
    {
        static void Main(string[] args)
        {
            byte n = byte.Parse(Console.ReadLine());
            int totalCalories=0;
            for (int i = 0; i < n; i++)
            {
                string ingredient = Console.ReadLine().ToLower();
                int calories = 0;
                switch (ingredient)
                {
                    case "cheese":
                        calories = 500;
                        break;
                    case "tomato sauce":
                        calories = 150;
                        break;
                    case "salami":
                        calories = 600;
                        break;
                    case "pepper":
                        calories = 50;
                        break;
                }
                totalCalories += calories;
            }
            Console.WriteLine($"Total calories: {totalCalories}");
        }
    }
}
