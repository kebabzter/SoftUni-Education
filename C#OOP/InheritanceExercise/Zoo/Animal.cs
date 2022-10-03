using System;
using System.Collections.Generic;
using System.Text;

namespace Zoo
{
    public class Animal
    {
        public Animal(string name,int age)
        {
            Name = name;
            Age = age;
        }
        public string Name { get; set; }

        public int Age { get; set; }
    }
}
