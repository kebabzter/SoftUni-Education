using SoftUni.Data;
using SoftUni.Models;
using System;
using System.Linq;
using System.Text;

namespace SoftUni
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            SoftUniContext db = new SoftUniContext();

            string result = AddNewAddressToEmployee(db);

            Console.WriteLine(result);
        }

     
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
    }
}
