using System;
using System.Collections.Generic;
using System.Text;

namespace Vehicles
{
    public class Truck:Vehicle
    {
        private const double airCondition = 1.6;

        public Truck(double quantity, double consumption) 
            : base(quantity, consumption)
        {
        }

        public override double Consumption => base.Consumption + airCondition;

        public override void Refuel(double amount)
        {
            base.Refuel(amount*0.95);
        }
    }
}
