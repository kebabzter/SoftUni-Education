using System;
using System.Collections.Generic;
using System.Linq;

namespace RawData
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            List<Car> listCar = new List<Car>();
            for (int i = 0; i < n; i++)
            {
                string[] input = Console.ReadLine()
                    .Split(" ", StringSplitOptions.RemoveEmptyEntries);
                Engine engine = new Engine(int.Parse(input[1]),int.Parse(input[2]));
                Cargo cargo = new Cargo(int.Parse(input[3]),input[4]);
                Car car = new Car(input[0]);
                car.EngineList.Add(engine);
                car.CargoList.Add(cargo);
                listCar.Add(car);
            }

            string filter = Console.ReadLine();
            listCar.OrderByDescending(x => x.Model);
            List<Car> result = new List<Car>();
            if (filter== "fragile")
            {
                foreach (var item in listCar)
                {
                    foreach (var cargo in item.CargoList)
                    {
                        if (cargo.CargoType=="fragile" && cargo.CargoWeight<1000)
                        {
                            Console.WriteLine(item.Model);
                        }
                    }
                }
            }
            else if (filter== "flamable")
            {
                foreach (var item in listCar)
                {
                    foreach (var cargo in item.CargoList)
                    {
                        if (cargo.CargoType == "flamable")
                        {
                           result.Add(item);
                        }
                    }
                }
                foreach (var engine in result)
                {
                    foreach (var enginePower in engine.EngineList)
                    {
                        if (enginePower.EnginePower>250)
                        {
                            Console.WriteLine(engine.Model);
                        }
                    }
                }

            }
        }
    }

    class Engine
    {
        public int EngineSpeed { get; set; }
        public int EnginePower { get; set; }
        public Engine(int speed,int power)
        {
            EngineSpeed = speed;
            EnginePower = power;
        }

    }

    class Cargo
    {
        public int CargoWeight { get; set; }
        public string CargoType { get; set; }
        public Cargo(int weight,string type)
        {
            CargoWeight = weight;
            CargoType = type;
        }
    }

    class Car
    {
        public string Model { get; set; }
        public List<Engine> EngineList { get; set; }
        public List<Cargo> CargoList { get; set; }
        public Car(string model)
        {
            Model = model;
            EngineList = new List<Engine>();
            CargoList = new List<Cargo>();
        }
    }
}
