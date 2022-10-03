using System;
using System.Collections.Generic;
using System.Text;

namespace Vehicles
{
    public class Bus : Vehicle
    {
        private const double airCondition = 1.4;
        public Bus(double quantity, double consumption, double capacity) 
            : base(quantity, consumption, capacity)
        {
        }

        public bool isEmpty { get; set; }
        public override double Consumption => isEmpty
            ? base.Consumption
            : base.Consumption+airCondition;
    }
}
