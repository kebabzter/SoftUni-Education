using System;
using System.Collections.Generic;
using System.Text;

namespace PersonsInfo
{
    public class Person
    {
        private string firstName;

        private string lastName;

        private int age;

        private decimal salary;

        public Person(string firstName, string lastName, int age, decimal salary)
        {
            FirstName = firstName;
            LastName = lastName;
            Age = age;
            Salary = salary;
        }

        public decimal Salary
        {
            get { return salary; }
            private set 
            {
                if (value<460)
                {
                    throw new ArgumentException("Salary cannot be less than 460 leva!");
                }
                salary = value; 
            }
        }
        public int Age
        {
            get { return age; }
            private set 
            {
                if (value<=0)
                {
                    throw new ArgumentException("Age cannot be zero or a negative integer!");
                }
                age = value; 
            }
        }

        public string LastName
        {
            get { return lastName; }
            private set 
            {
                if (value.Length<3)
                {
                    throw new ArgumentException("Last name cannot contain fewer than 3 symbols!");
                }
                lastName = value; 
            }
        }

        public string FirstName
        {
            get { return firstName; }
            private set 
            {
                if (value.Length < 3)
                {
                    throw new ArgumentException("First name cannot contain fewer than 3 symbols!");
                }
                firstName = value; 
            }
        }

        public override string ToString()
        {
            return $"{FirstName} {LastName} receives {Salary:f2} leva.";
        }

        public void IncreaseSalary(decimal percentage)
        {
            decimal increase = percentage;
            if (Age < 30)
            {
                increase /= 2;
            }
            Salary += Salary * increase / 100;
        }
    }
}
