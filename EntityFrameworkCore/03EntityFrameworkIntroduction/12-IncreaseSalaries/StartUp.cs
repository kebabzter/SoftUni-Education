using SoftUni.Data;
using SoftUni.Models;
using System;
using System.Globalization;
using System.Linq;
using System.Text;

namespace SoftUni
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            SoftUniContext db = new SoftUniContext();

            string result = IncreaseSalaries(db);
            Console.WriteLine(result);
        }

        public static string IncreaseSalaries(SoftUniContext context)
        {
            StringBuilder sb = new StringBuilder();

            var employeesIncrease = context.Employees
                .Where(e => e.Department.Name == "Engineering" || 
                            e.Department.Name == "Tool Design" || 
                            e.Department.Name == "Marketing" || 
                            e.Department.Name == "Information Services");

            foreach (var ei in employeesIncrease)
            {
                ei.Salary += ei.Salary * 0.12m;
            }

            context.SaveChanges();

            var employees = employeesIncrease
               .Select(e => new
               {
                   e.FirstName,
                   e.LastName,
                   e.Salary
               })
               .OrderBy(e=>e.FirstName)
               .ThenBy(e=>e.LastName)
               .ToArray();
            foreach (var e in employees)
            {
                sb.AppendLine($"{e.FirstName} {e.LastName} (${e.Salary:f2})");
            }

            return sb.ToString().TrimEnd();
        }
    }
}
