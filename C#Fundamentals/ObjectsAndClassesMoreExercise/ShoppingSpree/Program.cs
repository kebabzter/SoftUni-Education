using System;
using System.Collections.Generic;

namespace ShoppingSpree
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] allPeople = Console.ReadLine()
                .Split(";", StringSplitOptions.RemoveEmptyEntries);
            List<Person> people = new List<Person>();
            for (int i = 0; i < allPeople.Length; i++)
            {
                string[] currenPerson = allPeople[i].Split("=", StringSplitOptions.RemoveEmptyEntries);
                Person personCurrent = new Person(currenPerson[0], int.Parse(currenPerson[1]));
                people.Add(personCurrent);
            }
            string[] allProducts = Console.ReadLine()
                .Split(";", StringSplitOptions.RemoveEmptyEntries);
            List<Product> products = new List<Product>();
            for (int i = 0; i < allProducts.Length; i++)
            {
                string[] currenProduct = allProducts[i].Split("=", StringSplitOptions.RemoveEmptyEntries);
                Product productCurrent = new Product(currenProduct[0], int.Parse(currenProduct[1]));
                products.Add(productCurrent);
            }

            while (true)
            {
                string input = Console.ReadLine();
                if (input=="END")
                {
                    break;
                }
                string[] shop = input.Split(" ",StringSplitOptions.RemoveEmptyEntries);
                string nameBuy = shop[0];
                string productsBuy = shop[1];
                int personMoney = people.Find(x => x.Name == nameBuy).Money;
                int productCost = products.Find(x => x.Name == productsBuy).Cost;
                if (personMoney >= productCost)
                {
                    people.Find(x => x.Name == nameBuy).Money -= products.Find(x => x.Name == productsBuy).Cost;
                    Console.WriteLine($"{nameBuy} bought {productsBuy}");
                    people.Find(x => x.Name == nameBuy).Bag.Add(productsBuy);
                }
                else
                {
                    Console.WriteLine($"{nameBuy} can't afford {productsBuy}");
                }
            }

            foreach (var item in people)
            {
                Console.Write($"{item.Name} - ");
                if (people.Find(x => x.Name == item.Name).Bag.Count > 0)
                {
                    Console.WriteLine(string.Join(", ", people.Find(x => x.Name == item.Name).Bag));
                }
                else
                {
                    Console.WriteLine("Nothing bought");
                }

            }
        }
    }

    class Person
    {
        public string Name { get; set; }
        public int Money { get; set; }

        public List<string> Bag;
        public Person(string name, int money)
        {
            Name = name;
            Money = money;
            Bag = new List<string>();
        }

    }

    class Product
    {
        public string Name { get; set; }
        public int Cost { get; set; }
        public Product(string name, int cost)
        {
            Name = name;
            Cost = cost;
        }
    }
}
