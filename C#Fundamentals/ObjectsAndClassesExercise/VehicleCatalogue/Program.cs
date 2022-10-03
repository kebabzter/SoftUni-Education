using System;
using System.Collections.Generic;
using System.Linq;

namespace VehicleCatalogue
{
    class Program
    {
        static void Main(string[] args)
        {
            List<VehicleCatalogue> vehicleCatalogue = new List<VehicleCatalogue>();
            while (true)
            {
                string input = Console.ReadLine();
                if (input == "End")
                {
                    break;
                }

                string[] arrInput = input.Split(" ", StringSplitOptions.RemoveEmptyEntries);
                string typeOfVehicle = arrInput[0];
                string model = arrInput[1];
                string color = arrInput[2];
                int horsepower = int.Parse(arrInput[3]);
                VehicleCatalogue vehicle = new VehicleCatalogue(typeOfVehicle, model, color, horsepower);
                vehicleCatalogue.Add(vehicle);
            }

            while (true)
            {
                string inputModel = Console.ReadLine();
                if (inputModel == "Close the Catalogue")
                {
                    break;
                }

                foreach (var item in vehicleCatalogue)
                {
                    if (item.Model == inputModel)
                    {
                        if (item.Type == "car")
                        {
                            Console.WriteLine($"Type: Car");
                        }
                        else
                        {
                            Console.WriteLine($"Type: Truck");
                        }
                        Console.WriteLine($"Model: {item.Model}");
                        Console.WriteLine($"Color: {item.Color}");
                        Console.WriteLine($"Horsepower: {item.Horsepower}");
                    }
                }
            }

            List<VehicleCatalogue> cars = vehicleCatalogue.Where(x => x.Type == "car").ToList();
            Console.WriteLine($"Cars have average horsepower of: {GetAverage(cars):f2}.");
            List<VehicleCatalogue> trucks = vehicleCatalogue.Where(x => x.Type == "truck").ToList();
            Console.WriteLine($"Trucks have average horsepower of: {GetAverage(trucks):f2}.");
        }

        public static double GetAverage(List<VehicleCatalogue> vehicle)
        {
            int count = vehicle.Count;
            int horsepowerVehicle = vehicle.Sum(x => x.Horsepower);
            double averageVehicle = 0;
            if (count > 0)
            {
                averageVehicle = 1.0 * horsepowerVehicle / count;
            }
            return averageVehicle;
        }
    }

    class VehicleCatalogue
    {
        public string Type { get; set; }
        public string Model { get; set; }
        public string Color { get; set; }
        public int Horsepower { get; set; }
        public VehicleCatalogue(string type, string model, string color, int horsepower)
        {
            Type = type;
            Model = model;
            Color = color;
            Horsepower = horsepower;
        }
    }
}
