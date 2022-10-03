using System;
using System.Collections.Generic;
using System.Linq;

namespace CompanyRoster
{
    class Program
    {
        static void Main(string[] args)
        {
            List<Employee> listEmployee = new List<Employee>();
            int n = int.Parse(Console.ReadLine());
            for (int i = 0; i < n; i++)
            {
                string[] input = Console.ReadLine()
                    .Split(" ",StringSplitOptions.RemoveEmptyEntries);
                string name = input[0];
                decimal salary = decimal.Parse(input[1]);
                string position = input[2];
                string department = input[3];
                string email = "n/a";
                int age = -1;
                if (input.Length==6)
                {
                    email = input[4];
                    age = int.Parse(input[5]);
                }
                else if (input.Length==5)
                {
                    if (char.IsDigit(input[4][0]))
                    {
                        age = int.Parse(input[4]);
                    }
                    else
                    {
                        email = input[4];
                    }
                }
                Employee employee = new Employee(name,salary,position,department,email,age);
                listEmployee.Add(employee);
            }

            var filter = listEmployee.GroupBy(x => x.Department).OrderByDescending(y => y.Average(s => s.Salary)).First();
            Console.WriteLine($"Highest Average Salary: {filter.Key}");
            foreach (var item in listEmployee.Where(x=>x.Department==filter.Key).OrderByDescending(x=>x.Salary))
            {
                Console.WriteLine($"{item.Name} {item.Salary:f2} {item.Email} {item.Age}");
            }
        }
    }
}
