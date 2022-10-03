using System;
using System.Collections.Generic;
using System.Linq;

namespace SpeedRacing
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            Car[] cars = new Car[n];
            for (int i = 0; i < n; i++)
            {
                string[] info = Console.ReadLine()
                    .Split(" ", StringSplitOptions.RemoveEmptyEntries);
                string model = info[0];
                double fuelAmount = double.Parse(info[1]);
                double fuelConsumptionFor1km = double.Parse(info[2]);
                cars[i]= new Car(model, fuelAmount, fuelConsumptionFor1km);
            }

            while (true)
            {
                string[] input = Console.ReadLine()
                    .Split(" ", StringSplitOptions.RemoveEmptyEntries);
                if (input[0] == "End")
                {
                    break;
                }

                string carModel = input[1];
                double distance = double.Parse(input[2]);
                cars.Where(x => x.Model == carModel).ToList().ForEach(x=>x.Move(distance));
            }

            foreach (var item in cars)
            {
                Console.WriteLine(item);
            }
        }
    }
}
