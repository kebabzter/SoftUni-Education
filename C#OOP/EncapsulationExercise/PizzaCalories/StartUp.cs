using System;

namespace PizzaCalories
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            string[] pizzaName = Console.ReadLine().Split();
            string name = pizzaName[1];

            string[] doughInfo = Console.ReadLine().Split();
            string flour = doughInfo[1];
            string technique = doughInfo[2];
            int weightDough = int.Parse(doughInfo[3]);
            try
            {
                Dough dough = new Dough(flour, technique, weightDough);
                Pizza pizza = new Pizza(name, dough);

                while (true)
                {
                    string input = Console.ReadLine();
                    if (input == "END")
                    {
                        break;
                    }

                    string[] infoToping = input.Split();
                    string type = infoToping[1];
                    int weightTopping = int.Parse(infoToping[2]);
                    Topping topping = new Topping(type, weightTopping);
                    pizza.AddTopping(topping);
                }
                Console.WriteLine($"{pizza.Name} - {pizza.Calories():f2} Calories.");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}
