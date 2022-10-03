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

            string result = GetEmployeesInPeriod(db);

            Console.WriteLine(result);
        }

        public static string GetEmployeesInPeriod(SoftUniContext context)
        {
            StringBuilder sb = new StringBuilder();

            var employees = context.Employees
               .Where(e => e.EmployeesProjects.Any(p => p.Project.StartDate.Year >= 2001 && p.Project.StartDate.Year <= 2003))
               .Select(e => new
               {
                   e.FirstName,
                   e.LastName,
                   ManagerFN=e.Manager.FirstName,
                   ManagerLN=e.Manager.LastName,
                   Projects = e.EmployeesProjects.
                   Select(ep => new
                        {
                            ep.Project.Name,

                            StartDate =ep.Project.StartDate.
                            ToString("M/d/yyyy h:mm:ss tt", CultureInfo.InvariantCulture),

                            EndDate =ep.Project.EndDate == null ? "not finished" : ep.Project.EndDate.Value
                            .ToString("M/d/yyyy h:mm:ss tt", CultureInfo.InvariantCulture)
                        })
               })
               .Take(10)
               .ToArray();

            foreach (var e in employees)
            {
                sb.AppendLine($"{e.FirstName} {e.LastName} - Manager: {e.ManagerFN} {e.ManagerLN}");
                foreach (var project in e.Projects)
                {
                    sb.AppendLine($"--{project.Name} - {project.StartDate} - {project.EndDate}");
                }
            }

            return sb.ToString().TrimEnd();
        }
    }
}
