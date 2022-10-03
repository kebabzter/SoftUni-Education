using System;
using System.Collections.Generic;
using System.Text;

namespace CompanyRoster
{
    public class Employee
    {
        public Employee(string name,decimal salary,string position,string department,string email, int age)
        {
            Name = name;
            Salary = salary;
            Position = position;
            Department = department;
            Email = email;
            Age = age;
        }
       
        public string Name { get; set; }

        public decimal Salary { get; set; }

        public string Position { get; set; }

        public string Department { get; set; }

        public string Email { get; set; }

        public int Age { get; set; }
    }
}
