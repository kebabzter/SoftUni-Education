using System;
using System.Collections.Generic;
using System.Text;

namespace Vehicles
{
    public class Truck:Vehicle
    {
        private const double airCondition = 1.6;

        public Truck(double quantity, double consumption,double capacity) 
            : base(quantity, consumption,capacity)
        {
        }

        public override double Consumption => base.Consumption + airCondition;

        public override void Refuel(double amount)
        {
            if (base.Quantity+amount>Capacity)
            {
                throw new Exception($"Cannot fit {amount} fuel in the tank");
            }
            base.Refuel(amount*0.95);
        }
    }
}
