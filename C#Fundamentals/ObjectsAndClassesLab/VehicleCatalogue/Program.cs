using System;
using System.Collections.Generic;
using System.Linq;

namespace VehicleCatalogue
{
    class Program
    {
        static void Main(string[] args)
        {
            Catalog catalog = new Catalog();
            while (true)
            {
                string input = Console.ReadLine();

                if (input == "end")
                {
                    break;
                }

                string[] currentVehicle = input.Split("/",StringSplitOptions.RemoveEmptyEntries);
                
                if (currentVehicle[0]=="Car")
                {
                    Car car = new Car(currentVehicle[1],currentVehicle[2],int.Parse(currentVehicle[3]));
                    catalog.ListCar.Add(car);
                }
                else if (currentVehicle[0] == "Truck")
                {
                    Truck truck = new Truck(currentVehicle[1], currentVehicle[2], int.Parse(currentVehicle[3]));
                    catalog.ListTruck.Add(truck);
                }
            }

            var sortCar = catalog.ListCar.OrderBy(x => x.Brand).ToList();
            if (sortCar.Count>0)
            {
                Console.WriteLine("Cars:");
                foreach (var item in sortCar)
                {
                    Console.WriteLine($"{item.Brand}: {item.Model} - {item.HorsePower}hp");
                }
            }
           
            var sortTruck = catalog.ListTruck.OrderBy(x => x.Brand).ToList();
            if (sortTruck.Count>0)
            {
                Console.WriteLine("Trucks:");
                foreach (var item in sortTruck)
                {
                    Console.WriteLine($"{item.Brand}: {item.Model} - {item.Weight}kg");
                }
            }   
        }
    }
    class Truck
    {
        public string Brand { get; set; }
        public string Model { get; set; }
        public int Weight { get; set; }

        public Truck(string brand, string model, int weight)
        {
            Brand = brand;
            Model = model;
            Weight = weight;
        }
    }

    class Car
    {
        public string Brand { get; set; }
        public string Model { get; set; }
        public int HorsePower { get; set; }

        public Car(string brand, string model, int horsePower)
        {
            Brand = brand;
            Model = model;
            HorsePower = horsePower;
        }
    }

    class Catalog
    {
        public List<Car> ListCar { get; set; }
        public List<Truck> ListTruck { get; set; }
        public Catalog()
        {
            ListCar = new List<Car>();
            ListTruck = new List<Truck>();
        }
    }
}
