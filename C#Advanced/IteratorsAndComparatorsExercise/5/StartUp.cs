using System;
using System.Collections.Generic;

namespace ComparingObjects
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            List<Person> persons = new List<Person>();
            while (true)
            {
                string[] tokens = Console.ReadLine()
                    .Split(" ",StringSplitOptions.RemoveEmptyEntries);
                if (tokens[0]=="END")
                {
                    break;
                }

                persons.Add(new Person(tokens[0],int.Parse(tokens[1]),tokens[2])); 
            }
            int index = int.Parse(Console.ReadLine())-1;
            int equal = 0;
            int noEqual = 0;

            foreach (var person in persons)
            {
                if (persons[index].CompareTo(person)==0)
                {
                    equal++;
                }
                else
                {
                    noEqual++;
                }
            }

            if (equal<=1)
            {
                Console.WriteLine("No matches");
            }
            else
            {
                Console.WriteLine($"{equal} {noEqual} {persons.Count}");
            }
        }
    }
}
