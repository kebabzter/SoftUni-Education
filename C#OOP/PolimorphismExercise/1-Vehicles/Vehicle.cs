using System;
using System.Collections.Generic;
using System.Text;

namespace Vehicles
{
    public class Vehicle
    {
        public Vehicle(double quantity, double consumption)
        {
            Quantity = quantity;
            Consumption = consumption;
        }

        public double Quantity { get; private set; }
        public virtual double Consumption { get; private set; }

        public virtual void Refuel(double amount)
        {
            Quantity += amount;
        }

        public bool CanDrive(double distance)
        {
            bool canDrive = Quantity - Consumption * distance>=0;
            if (!canDrive)
            {
                return false;
            }
            Quantity -= Consumption * distance;
            return true;
        }
    }
}
