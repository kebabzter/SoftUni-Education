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
            string result = GetAddressesByTown(db);

            Console.WriteLine(result);
        }

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
    }
}
