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
            string result = RemoveTown(db);

            Console.WriteLine(result);
        }

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
    }
}
