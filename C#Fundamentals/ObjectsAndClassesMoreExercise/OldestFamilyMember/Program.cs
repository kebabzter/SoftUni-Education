using System;
using System.Collections.Generic;
using System.Linq;

namespace OldestFamilyMember
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            Family f = new Family();
            for (int i = 0; i < n; i++)
            {
                string[] input = Console.ReadLine()
                    .Split(" ",StringSplitOptions.RemoveEmptyEntries);
                Person p = new Person(input[0],int.Parse(input[1]));
               
                f.AddMember(p);
               
            }
            Console.WriteLine($"{f.GetOldestMember().Name} {f.GetOldestMember().Age}");
        }
    }

    class Person
    {
        public string Name { get; set; }
        public int Age{ get; set; }
        public Person(string name,int age)
        {
            Name = name;
            Age = age;
        }
    }

    class Family
    {
        public List<Person> People { get; set; }

        public Family()
        {
            People = new List<Person>();
        }
        public void AddMember(Person member)
        {
            People.Add(member);
        }

        public Person GetOldestMember()
        {
            return People.OrderByDescending(x=>x.Age).First();
        }
    }
}
