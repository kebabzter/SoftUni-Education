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

            //3.Employees Full Information
            //  string result = GetEmployeesFullInformation(db);

            //4.Employees with Salary Over 50 000
            // string result = GetEmployeesWithSalaryOver50000(db);

            //5. Employees from Research and Development
            //string result = GetEmployeesFromResearchAndDevelopment(db);

            //6. Adding a New Address and Updating Employee
            //string result = AddNewAddressToEmployee(db);

            //7.Employees and Projects
            //string result = GetEmployeesInPeriod(db);

            //8. Addresses by Town
            //string result = GetAddressesByTown(db);

            //9. Employee 147
            //string result = GetEmployee147(db);

            //10. Departments with More Than 5 Employees
            //string result = GetDepartmentsWithMoreThan5Employees(db);

            //11. Find Latest 10 Projects
            //string result = GetLatestProjects(db);

            //12. Increase Salaries
            //string result = IncreaseSalaries(db);

            //13. Find Employees by First Name Starting with "Sa"
            //string result = GetEmployeesByFirstNameStartingWithSa(db);

            //14. Delete Project by Id
            //string result = DeleteProjectById(db);

            //15. Remove Town
            string result = RemoveTown(db);

            Console.WriteLine(result);
        }

        //15. Remove Town
        public static string RemoveTown(SoftUniContext context)
        {
            Address[] addressesSeattle = context.Addresses
                .Where(a => a.Town.Name == "Seattle")
                .ToArray();

            Employee[] employeesSeattle = context.Employees.ToArray()
                .Where(e => addressesSeattle.Any(a => a.AddressId == e.AddressId))
                .ToArray();

            foreach (Employee employee in employeesSeattle)
            {
                employee.AddressId = null;
            }

            context.Addresses.RemoveRange(addressesSeattle);

            Town townSeattle = context.Towns
                .FirstOrDefault(t => t.Name == "Seattle");

            context.Towns.Remove(townSeattle);

            context.SaveChanges();

            return $"{addressesSeattle.Length} addresses in Seattle were deleted";
        }

        //14. Delete Project by Id
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

        //13. Find Employees by First Name Starting with "Sa"
        public static string GetEmployeesByFirstNameStartingWithSa(SoftUniContext context)
        {
            StringBuilder sb = new StringBuilder();

            var employees = context.Employees
                .Where(e=>e.FirstName.StartsWith("Sa"))
                .OrderBy(e => e.FirstName)
                .ThenBy(e=>e.LastName)
                .Select(e => new
                {
                    e.FirstName,
                    e.LastName,
                    e.JobTitle,
                    e.Salary
                })
                .ToArray();

            foreach (var e in employees)
            {
                sb.AppendLine($"{e.FirstName} {e.LastName} - {e.JobTitle} - (${e.Salary:f2})");
            }

            return sb.ToString().TrimEnd();
        }

        //12. Increase Salaries
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

        //11.Find Latest 10 Projects
        public static string GetLatestProjects(SoftUniContext context)
        {
            StringBuilder sb = new StringBuilder();

            var projects = context.Projects
                .OrderByDescending(p=>p.StartDate)
                .Select(p => new
                {
                    p.Name,
                    p.Description,
                    StartDate=p.StartDate.ToString("M/d/yyyy h:mm:ss tt", CultureInfo.InvariantCulture)
                })
                .Take(10)
                .ToArray();

            foreach (var item in projects.OrderBy(p => p.Name))
            {
                sb.AppendLine($"{item.Name}");
                sb.AppendLine($"{item.Description}");
                sb.AppendLine($"{item.StartDate}");
            }

            return sb.ToString().TrimEnd();
        }

        //10.	Departments with More Than 5 Employees
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


        //9. Employee 147
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

        //8. Addresses by Town
        public static string GetAddressesByTown(SoftUniContext context)
        {
            StringBuilder sb = new StringBuilder();

            var addresses = context.Addresses
              .Select(a => new 
              { 
                  a.AddressText, 
                  Count = a.Employees.Count(), 
                  TownName = a.Town.Name 
              })
              .OrderByDescending(a => a.Count)
              .ThenBy(a => a.TownName)
              .ThenBy(a => a.AddressText)
              .Take(10)
              .ToArray();

            foreach (var a in addresses)
            {
                sb.AppendLine($"{a.AddressText}, {a.TownName} - {a.Count} employees");
            }

            return sb.ToString().TrimEnd();
        }

        //7.Employees and Projects
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

                            StartDate =ep.Project.StartDate
                            .ToString("M/d/yyyy h:mm:ss tt", CultureInfo.InvariantCulture),

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

        //6. Adding a New Address and Updating Employee
        public static string AddNewAddressToEmployee(SoftUniContext context)
        {
            StringBuilder sb = new StringBuilder();

            Address newAdress = new Address();
            newAdress.AddressText = "Vitoshka 15";
            newAdress.TownId = 4;
            context.Addresses.Add(newAdress);

            Employee nakovEmployee = context.Employees
                .FirstOrDefault(e => e.LastName == "Nakov");
            nakovEmployee.Address = newAdress;

            context.SaveChanges();

            var employeesAddresses = context.Employees
                .OrderByDescending(e => e.AddressId)
                .Select(e => e.Address.AddressText)
                .Take(10)
                .ToArray();

         
            return String.Join(Environment.NewLine,employeesAddresses);
        }

        //5. Employees from Research and Development
        public static string GetEmployeesFromResearchAndDevelopment(SoftUniContext context)
        {
            StringBuilder sb = new StringBuilder();
            var employees = context.Employees
                .Where(d => d.Department.Name== "Research and Development")
                .OrderBy(e=>e.Salary)
                .ThenByDescending(e => e.FirstName)
                .Select(e => new
                {
                    e.FirstName,
                    e.LastName,
                    DepartmentName=e.Department.Name,
                    e.Salary
                })
                .ToArray();
            foreach (var e in employees)
            {
                sb.AppendLine($"{e.FirstName} {e.LastName} from {e.DepartmentName} - ${e.Salary:f2}");
            }
            return sb.ToString().TrimEnd();
        }

        //4. Employees with Salary Over 50 000
        public static string GetEmployeesWithSalaryOver50000(SoftUniContext context)
        {
            StringBuilder sb = new StringBuilder();
            var employees = context.Employees
                .Where(e => e.Salary > 50000)
                .OrderBy(e => e.FirstName)
                .Select(e => new
                {
                    e.FirstName,
                    e.Salary
                })
                .ToArray();
            foreach (var e in employees)
            {
                sb.AppendLine($"{e.FirstName} - {e.Salary:f2}");
            }
            return sb.ToString().TrimEnd();
        }

        //3.Employees Full Information
        public static string GetEmployeesFullInformation(SoftUniContext context)
        {
            StringBuilder sb = new StringBuilder();
            var employees = context.Employees.OrderBy(e => e.EmployeeId)
                .Select(e => new
                {
                    e.FirstName,
                    e.LastName,
                    e.MiddleName,
                    e.JobTitle,
                    e.Salary
                })
                .ToArray();
            foreach (var e in employees)
            {
                sb.AppendLine($"{e.FirstName} {e.LastName} {e.MiddleName} {e.JobTitle} {e.Salary:f2}");
            }
            return sb.ToString().TrimEnd();
        }

    
    }
}
