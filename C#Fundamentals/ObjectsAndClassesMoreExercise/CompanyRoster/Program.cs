using System;
using System.Collections.Generic;
using System.Linq;

namespace CompanyRoster
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            List<Employee> listEmployee = new List<Employee>();
            for (int i = 0; i < n; i++)
            {
                string[] input = Console.ReadLine()
                    .Split(" ",StringSplitOptions.RemoveEmptyEntries);
                Employee employee = new Employee(input[0],double.Parse(input[1]),input[2]);
                listEmployee.Add(employee);
            }

            var averageSalary = listEmployee
                .GroupBy(g=>g.Department,s=>s.Salary)
                .Select(g => new
                {
                    Department = g.Key,
                    AvgScore = g.Average()
                })
                .OrderByDescending(x=>x.AvgScore);

            Console.WriteLine($"Highest Average Salary: {averageSalary.First().Department}");
                var filter = listEmployee.Where(x => x.Department == averageSalary.First().Department).OrderByDescending(x => x.Salary);
                foreach (var nameSalary in filter)
                {
                    Console.WriteLine($"{nameSalary.Name} {nameSalary.Salary:f2}");
                }
          
        }
    }
    class Employee
    {
        public string Name { get; set; }
        public double Salary { get; set; }
        public string Department { get; set; }
        public Employee(string name,double salary,string department)
        {
            Name = name;
            Salary = salary;
            Department = department;
        }
    }
}
