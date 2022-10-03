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

            string result = GetEmployee147(db);

            Console.WriteLine(result);
        }

        public static string GetEmployee147(SoftUniContext context)
        {
            StringBuilder sb = new StringBuilder();

            var employee147 = context.Employees
                .Where(e => e.EmployeeId == 147)
                .Select(e => new
                {
                  e.FirstName,
                  e.LastName,
                  e.JobTitle,
                  Projects = e.EmployeesProjects
                              .Select(p => new { p.Project.Name })
                })
              .FirstOrDefault();

            sb.AppendLine($"{employee147.FirstName} {employee147.LastName} - {employee147.JobTitle}");
            foreach (var item in employee147.Projects.OrderBy(p => p.Name))
            {
                sb.AppendLine($"{item.Name}");
            }

            return sb.ToString().TrimEnd();
        }
    }
}
