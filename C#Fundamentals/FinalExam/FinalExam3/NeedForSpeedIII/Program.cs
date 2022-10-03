using System;
using System.Collections.Generic;
using System.Linq;

namespace NeedForSpeedIII
{
    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, int> mileageCar = new Dictionary<string, int>();
            Dictionary<string, int> fuelCar = new Dictionary<string, int>();
            int n=int.Parse(Console.ReadLine());
            for (int i = 0; i < n; i++)
            {
                string[] currentCar = Console.ReadLine()
                    .Split("|",StringSplitOptions.RemoveEmptyEntries);
                mileageCar.Add(currentCar[0],int.Parse(currentCar[1]));
                fuelCar.Add(currentCar[0],int.Parse(currentCar[2]));
            }

            while (true)
            {
                string input = Console.ReadLine();
                if (input=="Stop")
                {
                    break;
                }
                string[] commands = input.Split(" : ",StringSplitOptions.RemoveEmptyEntries);
                switch (commands[0])
                {
                    case "Drive":
                        //•	Drive : {car} : {distance} : {fuel} 
                        string carName = commands[1];
                        int distance = int.Parse(commands[2]);
                        int fuelDrive = int.Parse(commands[3]);
                        if (fuelDrive>fuelCar[carName])
                        {
                            Console.WriteLine("Not enough fuel to make that ride");
                        }
                        else
                        {
                            fuelCar[carName] -= fuelDrive;
                            mileageCar[carName] += distance;
                            Console.WriteLine($"{carName} driven for {distance} kilometers. {fuelDrive} liters of fuel consumed.");
                            if (mileageCar[carName]>=100000)
                            {
                                fuelCar.Remove(carName);
                                mileageCar.Remove(carName);
                                Console.WriteLine($"Time to sell the {carName}!");
                            }
                        }
                        break;
                    case "Refuel":
                        //•	Refuel : {car} : {fuel}
                        string carNameRefuel = commands[1];
                        int refuel = int.Parse(commands[2]);
                        if (fuelCar[carNameRefuel]+refuel>=75)
                        {
                            Console.WriteLine($"{carNameRefuel} refueled with {75-fuelCar[carNameRefuel]} liters");
                            fuelCar[carNameRefuel] = 75;
                        }
                        else
                        {
                            fuelCar[carNameRefuel] += refuel;
                            Console.WriteLine($"{carNameRefuel} refueled with {refuel} liters");
                        }
                        break;
                    case "Revert":
                        //•	Revert : {car} : {kilometers}
                        string carNameRevert = commands[1];
                        int kilometers = int.Parse(commands[2]);
                        mileageCar[carNameRevert] -= kilometers;
                        if (mileageCar[carNameRevert]<10000)
                        {
                            mileageCar[carNameRevert] = 10000;
                        }
                        else
                        {
                            Console.WriteLine($"{carNameRevert} mileage decreased by {kilometers} kilometers");
                        }
                        break;
                }
            }
            var sorted = mileageCar
                .OrderByDescending(x => x.Value)
                .ThenBy(x => x.Key)
                .ToDictionary(x => x.Key, x => x.Value);
            foreach (var item in sorted)
            {
                Console.WriteLine($"{item.Key} -> Mileage: {item.Value} kms, Fuel in the tank: {fuelCar[item.Key]} lt.");
            }
        }
    }
}
