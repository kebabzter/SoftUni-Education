using System;
using System.Collections.Generic;
using System.Text;

namespace Google
{
    public class Person
    {
        public Person(string name)
        {
            Name = name;
            Pokemons = new List<Pokemon>();
            Parents = new List<Parent>();
            Children = new List<Child>();
        }
        public string Name { get; set; }

        public Company Company { get; set; }

        public Car Car { get; set; }

        public List<Pokemon> Pokemons { get; set; }

        public List<Parent> Parents { get; set; }

        public List<Child> Children { get; set; }
    }
}
