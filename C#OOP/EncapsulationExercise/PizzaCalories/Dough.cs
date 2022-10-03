using System;
using System.Collections.Generic;
using System.Text;

namespace PizzaCalories
{
    public class Dough
    {
        private const double MinWeight = 1;
        private const double MaxWeight = 200;
        private const double Modifiers = 2;
        private const double White = 1.5;
        private const double Wholegrain = 1.0;
        private const double Crispy = 0.9;
        private const double Chewy = 1.1;
        private const double Homemade = 1.0;

        private string flourType;
        private string bakingTechnique;
        private double weight;

        public Dough(string flourType, string bakingTechnique, int weight)
        {
            FlourType = flourType;
            BakingTechnique = bakingTechnique;
            Weight = weight;
        }

        public string FlourType 
        { 
            get=>flourType;
            private set 
            {
                if (value.ToLower()!= "white"&&value.ToLower()!="wholegrain")
                {
                    throw new ArgumentException("Invalid type of dough.");
                }
                flourType = value;
            } 
        }

        public string BakingTechnique
        {
            get => bakingTechnique;
            private set
            {
                if (value.ToLower() != "crispy" && value.ToLower() != "chewy" && value.ToLower()!= "homemade")
                {
                    throw new ArgumentException("Invalid type of dough.");
                }
                bakingTechnique = value;
            } 
        }

        public double Weight 
        { 
            get=>weight;
            private set 
            {
                if (value<MinWeight || value>MaxWeight)
                {
                    throw new ArgumentException($"Dough weight should be in the range [{MinWeight}..{MaxWeight}].");
                }
                weight = value;
            } 
        }

        public double CalculateCalories()
        {
            double flour = 0;
            double technique = 0;

            string flourTypeLower = FlourType.ToLower();
            string bakingTechniqueLower = BakingTechnique.ToLower();

            if (flourTypeLower == "white")
            {
                flour = White;
            }
            else if (flourTypeLower == "wholegrain")
            {
                flour = Wholegrain;
            }

            if (bakingTechniqueLower == "crispy")
            {
                technique = Crispy;
            }
            else if (bakingTechniqueLower == "chewy")
            {
                technique = Chewy;
            }
            else if (bakingTechniqueLower == "homemade")
            {
                technique = Homemade;
            }
           
            return Modifiers * weight * flour * technique;
        }
    }
}
