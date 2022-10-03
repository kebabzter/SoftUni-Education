using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PizzaCalories
{
    public class Pizza
    {
        private string name;
        private List<Topping> toppings;
        private Dough dough;
        private const int MinName = 1;
        private const int MaxName = 15;
        private const int MinToppings = 0;
        private const int MaxToppings = 10;
        public Pizza(string name, Dough dough)
        {
            Name = name;
            this.dough = dough;
            toppings = new List<Topping>();
        }

        public string Name
        {
            get => this.name;
            private set
            {
                if (value.Length < MinName || value.Length > MaxName)
                {
                    throw new ArgumentException($"Pizza name should be between {MinName} and {MaxName} symbols.");
                }
                this.name = value;
            }
        }

        public void AddTopping(Topping topping)
        {
            if (toppings.Count == MaxToppings)
            {
                throw new ArgumentException($"Number of toppings should be in range [{MinToppings}..{MaxToppings}].");
            }

            toppings.Add(topping);
        }

        public double Calories()
        {
            return dough.CalculateCalories() + toppings.Sum(x => x.CalculateCalories());
        }

    }
}
