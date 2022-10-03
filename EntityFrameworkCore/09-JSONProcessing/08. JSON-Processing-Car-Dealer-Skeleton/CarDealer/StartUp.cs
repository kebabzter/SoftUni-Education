using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using AutoMapper;
using CarDealer.Data;
using CarDealer.DTO;
using CarDealer.Models;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;

namespace CarDealer
{
    public class StartUp
    {
        public static void Main(string[] args)
        {
            var db = new CarDealerContext();
            //db.Database.EnsureDeleted();
            //db.Database.EnsureCreated();

            //Query 8. Import Suppliers
            //var inputJson1 = File.ReadAllText("./../../../Datasets/suppliers.json");
            //var result1 = ImportSuppliers(db, inputJson1);
            //Console.WriteLine(result1);

            //Query 9. Import Parts
            // var inputJson2 = File.ReadAllText("./../../../Datasets/parts.json");
            // var result2 = ImportParts(db, inputJson2);
            // Console.WriteLine(result2);

            //Query 10. Import Cars
            //var inputJson = File.ReadAllText("./../../../Datasets/cars.json");
            // var result = ImportCars(db, inputJson);
            //  Console.WriteLine(result);

            //Query 11. Import Customers
            //var inputJson = File.ReadAllText("./../../../Datasets/customers.json");
            //var result = ImportCustomers(db, inputJson);
            //Console.WriteLine(result);

            //Query 12. Import Sales
            //var inputJson = File.ReadAllText("./../../../Datasets/sales.json");
            // var result = ImportSales(db, inputJson);
            // Console.WriteLine(result);

            //Query 13. Export Ordered Customers
            //Console.WriteLine(GetOrderedCustomers(db));

            //Query Export Cars from Make Toyota
            //Console.WriteLine(GetCarsFromMakeToyota(db));

            //Query 14. Export Local Suppliers
           // Console.WriteLine(GetLocalSuppliers(db));

            //Query 15. Export Cars with Their List of Parts
            //Console.WriteLine(GetCarsWithTheirListOfParts(db));

            //Query 16. Export Total Sales by Customer
            //Console.WriteLine(GetTotalSalesByCustomer(db));

            //Query 17. Export Sales with Applied Discount
            Console.WriteLine(GetSalesWithAppliedDiscount(db));
        }

        //Query 17. Export Sales with Applied Discount
        public static string GetSalesWithAppliedDiscount(CarDealerContext context)
        {
            var sales = context.Sales
               .Select(s => new
               {
                   car = new
                   {
                       Make = s.Car.Make,
                       Model = s.Car.Model,
                       TravelledDistance = s.Car.TravelledDistance
                   },
                   customerName = s.Customer.Name,
                   Discount = $"{s.Discount:f2}",
                   price = $"{s.Car.PartCars.Sum(cp => cp.Part.Price):f2}",
                   priceWithDiscount = $"{s.Car.PartCars.Sum(cp => cp.Part.Price) * ((100 - s.Discount) / 100):f2}"
               })
               .Take(10)
               .ToArray();
            var jsonSettings = new JsonSerializerSettings
            {
                Formatting = Formatting.Indented,
                //  ContractResolver = defaultContractResolver
            };

            var json = JsonConvert.SerializeObject(sales, jsonSettings);
            return json;
        }
        //Query 16. Export Total Sales by Customer
        public static string GetTotalSalesByCustomer(CarDealerContext context)
        {
            var customersSales = context.Customers.Where(x => x.Sales.Count>0)
                .Select(x=>new 
                {
                    fullName=x.Name,
                    boughtCars=x.Sales.Count,
                    spentMoney = x.Sales.Sum(s => s.Car.PartCars.Sum(cp => cp.Part.Price))
                })
                .OrderByDescending(c => c.spentMoney)
                .ThenByDescending(c => c.boughtCars)
                .ToArray();
                 var jsonSettings = new JsonSerializerSettings
                 {
                     Formatting = Formatting.Indented,
                     //  ContractResolver = defaultContractResolver
                 };

            var json = JsonConvert.SerializeObject(customersSales, jsonSettings);
            return json;
        }

        //Query 15. Export Cars with Their List of Parts
        public static string GetCarsWithTheirListOfParts(CarDealerContext context)
        {
            var suppliers = context.Cars
                          .Select(x => new
                          {
                              car=new
                              {
                                  Make = x.Make,
                                  Model = x.Model,
                                  TravelledDistance = x.TravelledDistance
                              },
                              parts = x.PartCars.Select(pc => new
                              {
                                  Name = pc.Part.Name,
                                  Price = $"{pc.Part.Price:F2}"
                              }).ToArray(),
                          }).ToArray();

            // DefaultContractResolver defaultContractResolver = new DefaultContractResolver
            // {
            //     NamingStrategy = new CamelCaseNamingStrategy()
            // };

            var jsonSettings = new JsonSerializerSettings
            {
                Formatting = Formatting.Indented,
                //  ContractResolver = defaultContractResolver
            };

            var json = JsonConvert.SerializeObject(suppliers, jsonSettings);
            return json;
        }

        //Query 14. Export Local Suppliers
        public static string GetLocalSuppliers(CarDealerContext context)
        {
            var suppliers = context.Suppliers
                .Where(s => s.IsImporter == false)
                .Select(s => new
                {
                    Id=s.Id,
                    Name=s.Name,
                    PartsCount = s.Parts.Count
                })
               .ToArray();

            // DefaultContractResolver defaultContractResolver = new DefaultContractResolver
            // {
            //     NamingStrategy = new CamelCaseNamingStrategy()
            // };

            var jsonSettings = new JsonSerializerSettings
            {
                Formatting = Formatting.Indented,
                //  ContractResolver = defaultContractResolver
            };

            var json = JsonConvert.SerializeObject(suppliers, jsonSettings);
            return json;
        }

        //Export Cars from Make Toyota
        public static string GetCarsFromMakeToyota(CarDealerContext context)
        {
            var cars = context.Cars
                .Where(c=>c.Make== "Toyota")
                .OrderBy(c => c.Model)
                .ThenByDescending(c=>c.TravelledDistance)
                .Select(c => new
                {
                     Id = c.Id,
                     Make=c.Make,
                     Model=c.Model,
                    TravelledDistance=c.TravelledDistance
                })
                .ToArray();

            // DefaultContractResolver defaultContractResolver = new DefaultContractResolver
            // {
            //     NamingStrategy = new CamelCaseNamingStrategy()
            // };

            var jsonSettings = new JsonSerializerSettings
            {
                Formatting = Formatting.Indented,
                //  ContractResolver = defaultContractResolver
            };

            var json = JsonConvert.SerializeObject(cars, jsonSettings);
            return json;
        }

        //Query 13. Export Ordered Customers
        public static string GetOrderedCustomers(CarDealerContext context)
        {
            var customers = context.Customers
                .OrderBy(c => c.BirthDate)
                .ThenBy(c=>c.IsYoungDriver)
                .Select(c => new
                {
                    Name = c.Name,
                    BirthDate = c.BirthDate.ToString("dd/MM/yyyy"),
                    IsYoungDriver = c.IsYoungDriver
                })
                .ToArray();

           // DefaultContractResolver defaultContractResolver = new DefaultContractResolver
           // {
           //     NamingStrategy = new CamelCaseNamingStrategy()
           // };

            var jsonSettings = new JsonSerializerSettings
            {
                Formatting = Formatting.Indented,
              //  ContractResolver = defaultContractResolver
            };

            var json = JsonConvert.SerializeObject(customers, jsonSettings);
            return json;
        }

        //Query 12. Import Sales
        public static string ImportSales(CarDealerContext context, string inputJson)
        {
            var sales = JsonConvert.DeserializeObject<Sale[]>(inputJson);
            context.Sales.AddRange(sales);
            context.SaveChanges();

            return $"Successfully imported {sales.Count()}.";
        }

        //Query 11. Import Customers
        public static string ImportCustomers(CarDealerContext context, string inputJson)
        {
            var customers = JsonConvert.DeserializeObject<Customer[]>(inputJson);
            context.Customers.AddRange(customers);
            context.SaveChanges();

            return $"Successfully imported {customers.Count()}.";
        }
        //Query 10. Import Cars
        public static string ImportCars(CarDealerContext context, string inputJson)
        {
            var carsDtos = JsonConvert.DeserializeObject<CarsInputModel[]>(inputJson);

            foreach (var carDto in carsDtos)
            {
                var currentCar = new Car
                {
                    Make = carDto.Make,
                    Model = carDto.Model,
                    TravelledDistance = carDto.TravelledDistance
                };

                foreach (var partId in carDto.PartsId.Distinct())
                {
                    var partCar = new PartCar
                    {
                        CarId = currentCar.Id,
                        PartId = partId
                    };

                    currentCar.PartCars.Add(partCar);
                }

                context.Cars.Add(currentCar);
            }

            context.SaveChanges();

            return $"Successfully imported {carsDtos.Count()}.";
        }
        //Query 9. Import Parts
        public static string ImportParts(CarDealerContext context, string inputJson)
        {
            var parts = JsonConvert.DeserializeObject<Part[]>(inputJson)
                .Where(p => context.Suppliers.Any(s => s.Id == p.SupplierId))
                .ToArray();
            context.Parts.AddRange(parts);
            context.SaveChanges();
            return $"Successfully imported {parts.Count()}.";
        }
        //Query 8. Import Suppliers
        public static string ImportSuppliers(CarDealerContext context, string inputJson)
        {
            var suppliers = JsonConvert.DeserializeObject<Supplier[]>(inputJson);
            context.Suppliers.AddRange(suppliers);
            context.SaveChanges();
            return $"Successfully imported {suppliers.Count()}.";
        }

      
    }

    
}