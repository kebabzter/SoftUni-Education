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
            string result = GetDepartmentsWithMoreThan5Employees(db);

            Console.WriteLine(result);
        }

        public static string GetDepartmentsWithMoreThan5Employees(SoftUniContext context)
        {
            StringBuilder sb = new StringBuilder();

            var departments = context.Departments
                .Where(d => d.Employees.Count() > 5)
                .OrderBy(d => d.Employees.Count())
                .ThenBy(d => d.Name)
                .Select(d => new
                {
                  d.Name,
                  ManagerFirstName=d.Manager.FirstName,
                  ManagerLastName = d.Manager.LastName,
                  EmployeeDepartment=d.Employees.Select(e=> new 
                                                        { e.FirstName,
                                                          e.LastName,
                                                          e.JobTitle})
                })
                .ToArray();

            foreach (var d in departments)
            {
                sb.AppendLine($"{d.Name} - {d.ManagerFirstName} {d.ManagerLastName}");
                foreach (var e in d.EmployeeDepartment.OrderBy(fn=>fn.FirstName).ThenBy(ln=>ln.LastName))
                {
                    sb.AppendLine($"{e.FirstName} {e.LastName} - {e.JobTitle}");
                }
            }

            return sb.ToString().TrimEnd();
        }
    }
}
