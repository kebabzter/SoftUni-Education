using System;
using System.Collections.Generic;
using System.Linq;


namespace ShoppingSpree
{
    public class Person
    {
        private string name;
        private decimal money;
        private List<Product> bagOfProducts;

        public Person(string name, decimal money)
        {
            Name = name;
            Money = money;
            bagOfProducts = new List<Product>();
        }
        public string Name
        {
            get => name;
            private set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException("Name cannot be empty");
                }
                name = value;
            }
        }

        public decimal Money
        {
            get => money;
            private set
            {
                if (value < 0)
                {
                    throw new ArgumentException("Money cannot be negative");
                }
                money = value;
            }
        }

        public IReadOnlyList<Product> BagOfProducts
        {
            get
            {
                return bagOfProducts.AsReadOnly();
            }
        }

        public void BuyProduct(Product product)
        {
            if (product.Cost > this.Money)
            {
                throw new InvalidOperationException($"{Name} can't afford {product.Name}");
            }

            bagOfProducts.Add(product);
            Money -= product.Cost;
        }

        public override string ToString()
        {
            if (bagOfProducts.Count == 0)
            {
                return $"{Name} - Nothing bought";
            }

            var products = bagOfProducts.Select(p => p.Name);

            return $"{Name} - {string.Join(", ", products)}";
        }
    }
}
