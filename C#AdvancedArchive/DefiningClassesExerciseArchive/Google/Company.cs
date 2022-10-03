using System;
using System.Collections.Generic;
using System.Text;

namespace Google
{
    public class Company
    {
        public Company(string name, string department, decimal salary)
        {
            Name = name;
            Department = department;
            Salary = salary;
        }
        public string Name { get; set; }

        public string Department { get; set; }

        public decimal Salary { get; set; }

        public override string ToString()
        {
            return $"{Name} {Department} {Salary:f2}";
        }
    }
}
