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

            string result = DeleteProjectById(db);

            Console.WriteLine(result);
        }

        public static string DeleteProjectById(SoftUniContext context)
        {
            var employeeProjects = context.EmployeesProjects
                .Where(ep => ep.ProjectId == 2)
                .ToList();
            if (employeeProjects.Count > 0)
            {
                context.RemoveRange(employeeProjects);
            }

            var project = context.Projects.Find(2);
            if (project != null)
            {
                context.Remove(project);
            }

            context.SaveChanges();

            return string.Join(Environment.NewLine, context.Projects.Select(p => p.Name).Take(10));
        }
    }
}
