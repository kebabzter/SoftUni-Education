using System;

namespace Vehicles
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            string[] carInput = Console.ReadLine()
                .Split(" ",StringSplitOptions.RemoveEmptyEntries);
            string[] truckInput = Console.ReadLine()
               .Split(" ", StringSplitOptions.RemoveEmptyEntries);
            Car car = new Car(double.Parse(carInput[1]), double.Parse(carInput[2]));
            Truck truck = new Truck(double.Parse(truckInput[1]), double.Parse(truckInput[2]));

            int n = int.Parse(Console.ReadLine());
            for (int i = 0; i < n; i++)
            {
                string[] input = Console.ReadLine()
                            .Split(" ", StringSplitOptions.RemoveEmptyEntries);
                string command = input[0];
                string type = input[1];
                double amount = double.Parse(input[2]);

                if (command=="Drive")
                {
                    if (type=="Car")
                    {
                        Drive(car, amount);
                    }
                    else if (type=="Truck")
                    {
                        Drive(truck, amount);
                    }

                }
                else if (command=="Refuel")
                {
                    if (type == "Car")
                    {
                        car.Refuel(amount);
                    }
                    else if (type == "Truck")
                    {
                        truck.Refuel(amount);
                    }
                }
            }

            Console.WriteLine($"Car: {car.Quantity:f2}");
            Console.WriteLine($"Truck: {truck.Quantity:f2}");
        }

        public static void Drive(Vehicle vehicle,double distance)
        {
            bool canDrive = vehicle.CanDrive(distance);
            string vehicleType = vehicle.GetType().Name;
            if (canDrive)
            {
                Console.WriteLine($"{vehicleType} travelled {distance} km");
            }
            else
            {
                Console.WriteLine($"{vehicleType} needs refueling");
            }
        }
    }
}
