using System;
using System.Collections.Generic;
using System.Linq;

namespace RawData
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            List<Car> cars = new List<Car>();
            int n = int.Parse(Console.ReadLine());
            for (int i = 0; i < n; i++)
            {
                string[] input = Console.ReadLine()
                    .Split(" ",StringSplitOptions.RemoveEmptyEntries);
                string carModel = input[0];

                Engine engine = new Engine(int.Parse(input[1]),int.Parse(input[2]));

                Cargo cargo = new Cargo(int.Parse(input[3]),input[4]);

                Tire[] tires = new Tire[]
                {
                    new Tire(double.Parse(input[5]),int.Parse(input[6])),
                    new Tire(double.Parse(input[7]),int.Parse(input[8])),
                    new Tire(double.Parse(input[9]),int.Parse(input[10])),
                    new Tire(double.Parse(input[11]),int.Parse(input[12])),
                };

                Car car = new Car(carModel,engine,cargo,tires);
                cars.Add(car);
            }

            string type = Console.ReadLine();
            List<Car> filter = new List<Car>();
            if (type== "fragile")
            {
                filter = cars.Where(x => x.Cargo.Type == type && x.Tires.Any(p => p.Pressure < 1)).ToList();
            }
            else
            {
                filter = cars.Where(x => x.Cargo.Type == type && x.Engine.Power>250).ToList();
            }

            foreach (var item in filter)
            {
                Console.WriteLine(item.Model);
            }
        }
    }
}
