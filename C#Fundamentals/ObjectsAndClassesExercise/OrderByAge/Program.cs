using System;
using System.Collections.Generic;
using System.Linq;

namespace OrderByAge
{
    class Program
    {
        static void Main(string[] args)
        {
            List<Person> personList = new List<Person>();
            while (true)
            {
                string input = Console.ReadLine();
                if (input=="End")
                {
                    break;
                }

                string[] info = input.Split(" ",StringSplitOptions.RemoveEmptyEntries);
                Person person = new Person(info[0],info[1],int.Parse(info[2]));
                personList.Add(person);
            }

            var filterList = personList.OrderBy(x => x.Age).ToList();
            foreach (var item in filterList)
            {
                Console.WriteLine(item);
            }
        }
    }

    class Person
    {
        public string Name { get; set; }
        public string Id { get; set; }
        public int Age { get; set; }
        public Person(string name,string id, int age)
        {
            Name = name;
            Id = id;
            Age = age;
        }
        public override string ToString()
        {
            return $"{Name} with ID: {Id} is {Age} years old.";
        }
    }
}
