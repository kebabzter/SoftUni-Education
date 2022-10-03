using System;
using System.Collections.Generic;
using System.Text;

namespace EasterRaces.Models.Cars.Entities
{
    public class MuscleCar : Car
    {
        private const double DefaultCubicCentimeters = 5000;
        private const int DefaultMinHP=400;
        private const int DefaultMaxHP=600;

        public MuscleCar(string model, int horsePower) 
            : base(model, horsePower, DefaultCubicCentimeters, DefaultMinHP, DefaultMaxHP)
        {
        }
    }
}
