using System;
using System.Collections.Generic;
using System.Text;

namespace SpeedRacing
{
    public class Car
    {
        public Car(string model, double fuelAmount, double fuelConsKl)
        {
            Model = model;
            FuelAmount = fuelAmount;
            FuelConsumptionPerKilometer = fuelConsKl;
            Travelled = 0;
        }

        public string Model { get; set; }

        public double FuelAmount { get; set; }

        public double FuelConsumptionPerKilometer { get; set; }

        public double Travelled { get; set; }

        public void Move(double distance)
        {
            double needFuel = distance * FuelConsumptionPerKilometer;
            if (FuelAmount>=needFuel)
            {
                FuelAmount -= needFuel;
                Travelled += distance;
            }
            else
            {
                Console.WriteLine("Insufficient fuel for the drive");
            }
        }

        public override string ToString()
        {
            return $"{Model} {FuelAmount:f2} {Travelled}";
        }
    }
}
