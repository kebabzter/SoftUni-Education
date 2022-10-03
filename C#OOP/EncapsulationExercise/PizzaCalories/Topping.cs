using System;
using System.Collections.Generic;
using System.Text;

namespace PizzaCalories
{
    public class Topping
    {
        private const double MinWeight = 1;
        private const double MaxWeight = 50;
        private const double Modifiers = 2;
        private const double Meat = 1.2;
        private const double Veggies = 0.8;
        private const double Cheese = 1.1;
        private const double Sauce = 0.9;

        private string type;
        private double weight;

        public Topping(string type, double weight)
        {
            Type = type;
            Weight = weight;
        }
        public string Type
        {
            get { return type; }
            private set
            {
                if (value.ToLower()!= "meat"&& value.ToLower() != "veggies" && value.ToLower() != "cheese" && value.ToLower() != "sauce")
                {
                    throw new ArgumentException($"Cannot place {value} on top of your pizza.");
                }
                type = value; 
            }
        }

        public double Weight
        {
            get => weight;
            private set
            {
                if (value < MinWeight || value > MaxWeight)
                {
                    throw new ArgumentException($"{Type} weight should be in the range [{MinWeight}..{MaxWeight}].");
                }
                weight = value;
            }
        }

        public double CalculateCalories()
        {
            double topping = 0;

            string typeLower = Type.ToLower();

            if (typeLower == "meat")
            {
                topping = Meat;
            }
            else if (typeLower == "veggies")
            {
                topping = Veggies;
            }
            else if (typeLower == "cheese")
            {
                topping = Cheese;
            }
            else if (typeLower == "sauce")
            {
                topping = Sauce;
            }

            return Modifiers * weight * topping;
        }

    }
}
