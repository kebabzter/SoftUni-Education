using System;
using System.Collections.Generic;
using System.Linq;

namespace Google
{
    public class Program
    {
        static void Main(string[] args)
        {
            List<Person> people = new List<Person>();
            while (true)
            {
                string input = Console.ReadLine();
                if (input=="End")
                {
                    break;
                }

                string[] info = input.Split(" ",StringSplitOptions.RemoveEmptyEntries);
                string name = info[0];
                string data = info[1];
                if (!people.Any(x => x.Name == name))
                {
                    Person person = new Person(name);
                    people.Add(person);
                }
                switch (data)
                {
                    case "company":
                        //•	“<Name> company <companyName> <department> <salary>”  
                        string companyName = info[2];
                        string department = info[3];
                        decimal salary = decimal.Parse(info[4]);
                        Company company = new Company(companyName,department,salary);
                        people.Where(x => x.Name == name).First().Company = company;
                        break;
                    case "pokemon":
                        //•	“<Name> pokemon <pokemonName> <pokemonType>”
                        string pokemonName = info[2];
                        string pokemonType = info[3];
                        Pokemon pokemon = new Pokemon(pokemonName,pokemonType);
                        people.Where(x => x.Name == name).First().Pokemons.Add(pokemon);
                        break;
                    case "parents":
                        //•	“<Name> parents <parentName> <parentBirthday>”
                        string parentName = info[2];
                        string parentBirthday = info[3];
                        Parent parent = new Parent(parentName,parentBirthday);
                        people.Where(x => x.Name == name).First().Parents.Add(parent);
                        break;
                    case "children":
                        //•	“<Name> children <childName> <childBirthday>”
                        string childName = info[2];
                        string childBirthday = info[3];
                        Child child = new Child(childName, childBirthday);
                        people.Where(x => x.Name == name).First().Children.Add(child);
                        break;
                    case "car":
                        //•	“<Name> car <carModel> <carSpeed>”
                        string carName = info[2];
                        int carSpeed = int.Parse(info[3]);
                        Car car = new Car(carName, carSpeed);
                        people.Where(x => x.Name == name).First().Car = car;
                        break;
                }
            }

            string filter = Console.ReadLine();
            Person filterPerson = people.Where(x => x.Name == filter).First();
            Console.WriteLine(filterPerson.Name);
            Console.WriteLine("Company:");
            if (filterPerson.Company!=null)
            {
                Console.WriteLine(filterPerson.Company);
            }
            Console.WriteLine("Car:");
            if (filterPerson.Car!=null)
            {
                Console.WriteLine(filterPerson.Car);
            }
            Console.WriteLine("Pokemon:");
            foreach (var item in filterPerson.Pokemons)
            {
                Console.WriteLine(item);
            }
            Console.WriteLine("Parents:"); 
            foreach (var item in filterPerson.Parents)
            {
                Console.WriteLine(item);
            }
            Console.WriteLine("Children:");
            foreach (var item in filterPerson.Children)
            {
                Console.WriteLine(item);
            }
        }
    }
}
