using System;
using System.Collections.Generic;
using System.Linq;

namespace SpeedRacing
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
                Car car = new Car(input[0],double.Parse(input[1]),double.Parse(input[2]));
                listCar.Add(car);
            }

            while (true)
            {
                string info = Console.ReadLine();
                if (info=="End")
                {
                    break;
                }
                string[] arrInfo = info.Split(" ", StringSplitOptions.RemoveEmptyEntries);
                string carModel = arrInfo[1];
                double amountOfKm = double.Parse(arrInfo[2]);
                var currentCarAmount = listCar.Where(x => x.Model == carModel).First();
                
                currentCarAmount.FuelAmount -=currentCarAmount.FuelConsumptionFor1km * amountOfKm;
                if (currentCarAmount.FuelAmount<0)
                {
                    currentCarAmount.FuelAmount += currentCarAmount.FuelConsumptionFor1km * amountOfKm;
                    Console.WriteLine("Insufficient fuel for the drive");
                    continue;
                }
                listCar.Where(x => x.Model == carModel).First().TraveledDistance+=amountOfKm;
            }

            foreach (var item in listCar)
            {
                Console.WriteLine($"{item.Model} {item.FuelAmount:f2} {item.TraveledDistance}");
            }
        }
    }

    class Car 
    {
        public string Model { get; set; }
        public double FuelAmount { get; set; }
        public double FuelConsumptionFor1km { get; set; }
        public double TraveledDistance { get; set; }

        public Car(string model,double amount,double consumption)
        {
            Model = model;
            FuelAmount = amount;
            FuelConsumptionFor1km = consumption;
            TraveledDistance = 0;
        }
    }
}
