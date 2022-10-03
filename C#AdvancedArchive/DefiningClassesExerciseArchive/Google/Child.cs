using System;
using System.Collections.Generic;
using System.Text;

namespace Google
{
    public class Child
    {
        public Child(string name, string birthday)
        {
            Name = name;
            Birthday = birthday;
        }
        public string Name { get; set; }

        public string Birthday { get; set; }

        public override string ToString()
        {
            return $"{Name} {Birthday}";
        }
    }
}
