using System;

namespace EmployeeData
{
    class Program
    {
        static void Main(string[] args)
        {
            string name = Console.ReadLine();
            int age = int.Parse(Console.ReadLine());
            int employee = int.Parse(Console.ReadLine());
            double monthlySalary = double.Parse(Console.ReadLine());
            Console.WriteLine($"Name: {name}");
            Console.WriteLine($"Age: {age}");
            Console.WriteLine($"Employee ID: {employee:D8}");
            Console.WriteLine($"Salary: {monthlySalary:f2}");
        }
    }
}
