using System;
using System.Collections.Generic;
using System.Linq;

namespace CarManufacturer
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            List<Tire[]> listTire = new List<Tire[]>();
            List<Engine> listEngine = new List<Engine>();
            List<Car> listCar = new List<Car>();

            while (true)
            {
                string input = Console.ReadLine();
                if (input == "No more tires")
                {
                    break;
                }
                var info = input.Split(" ", StringSplitOptions.RemoveEmptyEntries);
                var tires = new Tire[info.Length / 2];
                int indexTires = 0;
                for (int i = 0; i < info.Length; i += 2)
                {
                    int year = int.Parse(info[i]);
                    double pressure = double.Parse(info[i + 1]);
                    tires[indexTires] = new Tire(year, pressure);
                    indexTires++;
                }
                listTire.Add(tires);
            }

            while (true)
            {
                string input = Console.ReadLine();
                if (input == "Engines done")
                {
                    break;
                }
                var infoEngine = input
                    .Split(" ", StringSplitOptions.RemoveEmptyEntries);
                for (int i = 0; i < infoEngine.Length; i += 2)
                {
                    int power = int.Parse(infoEngine[i]);
                    double capacity = double.Parse(infoEngine[i + 1]);
                    Engine currentEngine = new Engine(power, capacity);
                    listEngine.Add(currentEngine);
                }
            }

            while (true)
            {
                string input = Console.ReadLine();
                if (input == "Show special")
                {
                    break;
                }

                var infoCar = input
                    .Split(" ", StringSplitOptions.RemoveEmptyEntries);
                string make = infoCar[0];
                string model = infoCar[1];
                int year = int.Parse(infoCar[2]);
                double fuelQuantity = double.Parse(infoCar[3]);
                double fuelConsumption = double.Parse(infoCar[4]);
                int engineIndex = int.Parse(infoCar[5]);
                int tiresIndex = int.Parse(infoCar[6]);
                Car currentCar = new Car(make, model, year, fuelQuantity, fuelConsumption, listEngine[engineIndex], listTire[tiresIndex]);
                listCar.Add(currentCar);
            }

            var filter = listCar
                .Where(x => x.Year >= 2017)
                .Where(x => x.Engine.HorsePower > 330)
                .Where(x => x.Tires.Sum(y => y.Pressure) >= 9 && x.Tires.Sum(y => y.Pressure) <= 10)
                .ToList();

            foreach (var specialCar in filter)
            {
                specialCar.Drive(20);
                Console.WriteLine($"Make: {specialCar.Make}");
                Console.WriteLine($"Model: {specialCar.Model}");
                Console.WriteLine($"Year: {specialCar.Year}");
                Console.WriteLine($"HorsePowers: {specialCar.Engine.HorsePower}");
                Console.WriteLine($"FuelQuantity: {specialCar.FuelQuantity}");
            }
        }
    }
}
