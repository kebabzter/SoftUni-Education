using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using ProductShop.Data;
using ProductShop.Models;

namespace ProductShop
{
    public class StartUp
    {
        public static void Main(string[] args)
        {
            var db = new ProductShopContext();
            //db.Database.EnsureDeleted();
            //db.Database.EnsureCreated();

            //Query 2. Import Users
            // var inputJson = File.ReadAllText("./../../../Datasets/users.json");
            // var result = ImportUsers(db, inputJson);
            // Console.WriteLine(result);

            //Query 3. Import Products
            //  var inputJson3 = File.ReadAllText("./../../../Datasets/products.json");
            //  var result3 = ImportProducts(db, inputJson3);
            // Console.WriteLine(result3);

            //Query 4. Import Categories
            // var inputJson4 = File.ReadAllText("./../../../Datasets/categories.json");
            // var result4 = ImportCategories(db, inputJson4);
            // Console.WriteLine(result4);


            //Query 5.Import Categories and Products
            //var inputJson5 = File.ReadAllText("./../../../Datasets/categories-products.json");
            //var result5 = ImportCategoryProducts(db, inputJson5);
            //Console.WriteLine(result5);

            //Export Products in Range
            //var result = GetProductsInRange(db);
            //Console.WriteLine(result);

            //Query 6. Export Successfully Sold Products
            //var result = GetSoldProducts(db);
            //Console.WriteLine(result);

            //Export Categories by Products Count
            //var result = GetCategoriesByProductsCount(db);
            //Console.WriteLine(result);

            //Query 7. Export Users and Products
            var result = GetUsersWithProducts(db);
            Console.WriteLine(result);
        }

        //Query 7. Export Users and Products
        public static string GetUsersWithProducts(ProductShopContext context)
        {
            var users = context.Users
                 .Include(x => x.ProductsSold)
                 .ThenInclude(x => x.Buyer)
                 .Where(u => u.ProductsSold.Any(ps => ps.Buyer != null))
                 .ToList();

            var usersProducts = new
            {
                UsersCount = users.Count(),
                Users = users
                .Select(x => new
                {
                    FirstName = x.FirstName,
                    LastName = x.LastName,
                    Age = x.Age,
                    SoldProducts = new
                    {
                        count = x.ProductsSold.Count(p => p.Buyer != null),
                        Products = x.ProductsSold
                        .Where(p => p.Buyer != null)
                        .Select(p => new
                        {
                            Name = p.Name,
                            Price = p.Price
                        })
                        .ToList()
                    }
                })
                .OrderByDescending(x => x.SoldProducts.count)
                .ToList()
            };

            DefaultContractResolver defaultContractResolver = new DefaultContractResolver
            {
                NamingStrategy = new CamelCaseNamingStrategy()
            };

            var jsonSettings = new JsonSerializerSettings
            {
                Formatting = Formatting.Indented,
                NullValueHandling=NullValueHandling.Ignore,
                ContractResolver = defaultContractResolver
            };

            var json = JsonConvert.SerializeObject(usersProducts, jsonSettings);
            return json;
        }

        //Export Categories by Products Count
        public static string GetCategoriesByProductsCount(ProductShopContext context)
        {
            var categories = context.Categories
                .OrderByDescending(c => c.CategoryProducts.Count)
                .Select(c=>new 
                {
                    category=c.Name,
                    productsCount=c.CategoryProducts.Count,
                    averagePrice=$"{c.CategoryProducts.Average(cp=>cp.Product.Price):f2}",
                    totalRevenue= $"{c.CategoryProducts.Sum(cp => cp.Product.Price):f2}"
                })
                .ToArray();

            DefaultContractResolver defaultContractResolver = new DefaultContractResolver
            {
                NamingStrategy = new CamelCaseNamingStrategy()
            };

            var jsonSettings = new JsonSerializerSettings
            {
                Formatting = Formatting.Indented,
                ContractResolver = defaultContractResolver
            };

            var json = JsonConvert.SerializeObject(categories, jsonSettings);
            return json;
        }

        // Query 6. Export Successfully Sold Products
        public static string GetSoldProducts(ProductShopContext context)
        {
            var soldProducts = context.Users
                .Where(u => u.ProductsSold.Any(x => x.Buyer != null))
                .OrderBy(u => u.LastName)
                .ThenBy(u => u.FirstName)
                .Select(x => new
                {
                    firstName = x.FirstName,
                    lastName = x.LastName,
                    soldProducts = x.ProductsSold.Select(p => new
                    {
                        name = p.Name,
                        price=p.Price,
                        buyerFirstName=p.Buyer.FirstName,
                        buyerLastName=p.Buyer.LastName
                    })
                })
                .ToArray();

            DefaultContractResolver defaultContractResolver = new DefaultContractResolver
            {
                NamingStrategy=new CamelCaseNamingStrategy()
            };

            var jsonSettings = new JsonSerializerSettings
            {
                Formatting=Formatting.Indented,
                ContractResolver=defaultContractResolver
            };

            var json = JsonConvert.SerializeObject(soldProducts, jsonSettings);
            return json;
        }

        //Export Products in Range
        public static string GetProductsInRange(ProductShopContext context)
        {
            var products = context.Products
                .Where(p => p.Price >= 500 && p.Price <= 1000)
                .OrderBy(p => p.Price)
                .Select(p => new
                {
                    name = p.Name,
                    price=p.Price,
                    seller=$"{p.Seller.FirstName} {p.Seller.LastName}"
                })
                .ToArray();

            var json = JsonConvert.SerializeObject(products, Formatting.Indented);
            return json;
        }

        // Query 5. Import Categories and Products
        public static string ImportCategoryProducts(ProductShopContext context, string inputJson)
        {
            var categoryProducts = JsonConvert.DeserializeObject<CategoryProduct[]>(inputJson);
            context.CategoryProducts.AddRange(categoryProducts);
            context.SaveChanges();
            return $"Successfully imported {categoryProducts.Length}";
        }
        //Query 4. Import Categories
        public static string ImportCategories(ProductShopContext context, string inputJson)
        {
            var categories = JsonConvert.DeserializeObject<Category[]>(inputJson).Where(c=>c.Name!=null).ToArray();
            context.Categories.AddRange(categories);
            context.SaveChanges();
            return $"Successfully imported {categories.Length}";
        }

        //Query 3. Import Products
        public static string ImportProducts(ProductShopContext context, string inputJson)
        {
            var products = JsonConvert.DeserializeObject<List<Product>>(inputJson);
            context.Products.AddRange(products);
            context.SaveChanges();
            return $"Successfully imported {products.Count}";
        }

        //Query 2. Import Users

        public static string ImportUsers(ProductShopContext context, string inputJson)
        {
            var users = JsonConvert.DeserializeObject<User[]>(inputJson);
            context.Users.AddRange(users);
            context.SaveChanges();
            return $"Successfully imported {users.Length}";
        }
    }
}