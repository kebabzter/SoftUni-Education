using System;
using System.Collections.Generic;
using System.Text;

namespace Vehicles
{
    public class Vehicle
    {
        private double quantity;
        public Vehicle(double quantity, double consumption, double capacity)
        {
            Capacity = capacity;
            Quantity = quantity;
            Consumption = consumption;
        }

        public double Quantity
        {
            get => quantity;
            private set
            {
                if (value > Capacity)
                {
                    value = 0;
                }
                else
                {
                    quantity = value;
                }
            }
        }
        public virtual double Consumption { get; private set; }

        public double Capacity { get; private set; }

        public virtual void Refuel(double amount)
        {
            if (amount<=0)
            {
                throw new Exception("Fuel must be a positive number");
            }

            if (amount>Capacity)
            {
                throw new Exception($"Cannot fit {amount} fuel in the tank");
            }
            Quantity += amount;
        }

        public bool CanDrive(double distance)
        {
            bool canDrive = Quantity - Consumption * distance >= 0;
            if (!canDrive)
            {
                return false;
            }
            Quantity -= Consumption * distance;
            return true;
        }
    }
}
