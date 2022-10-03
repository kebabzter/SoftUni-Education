using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CocktailParty
{
    public class Cocktail
    {
        public Cocktail(string name, int capacity, int maxAlcoholLevel)
        {
            Name = name;
            Capacity = capacity;
            MaxAlcoholLevel = maxAlcoholLevel;
            Ingredients = new List<Ingredient>();
        }
        public string Name { get; set; }

        public int Capacity { get; set; }

        public int MaxAlcoholLevel { get; set; }

        public List<Ingredient> Ingredients { get; set; }

        public int CurrentAlcoholLevel => Ingredients.Sum(x => x.Alcohol);
        public void Add(Ingredient ingredient)
        {
            if (!Ingredients.Any(x => x.Name == ingredient.Name && ingredient.Quantity <= Capacity && ingredient.Alcohol <= MaxAlcoholLevel))
            {
                Ingredients.Add(ingredient);
                Capacity -= ingredient.Quantity;
                MaxAlcoholLevel -= ingredient.Alcohol;
            }
        }

        public bool Remove(string name)
        {
            var info = Ingredients.FirstOrDefault(x => x.Name == name);
            if (info != null)
            {
                Ingredients.Remove(info);
                return true;
            }
            else
            {
                return false;
            }
        }

        public Ingredient FindIngredient(string name)
        {
            return Ingredients.Where(x => x.Name == name).FirstOrDefault();
        }

        public Ingredient GetMostAlcoholicIngredient()
        {
            return Ingredients.OrderByDescending(x => x.Alcohol).FirstOrDefault();
        }

        public string Report()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"Cocktail: {Name} - Current Alcohol Level: {CurrentAlcoholLevel}");
            foreach (var item in Ingredients)
            {
                sb.AppendLine(item.ToString());
            }
            return sb.ToString().TrimEnd();
        }
    }
}
