using System;
using System.Collections.Generic;
using System.Text;

namespace Vehicles
{
    public class Car : Vehicle
    {
        private const double airCondition = 0.9;
        public Car(double quantity, double consumption,double capacity) 
            : base(quantity, consumption,capacity)
        {
        }

        public override double Consumption => base.Consumption+airCondition;
    }
}
