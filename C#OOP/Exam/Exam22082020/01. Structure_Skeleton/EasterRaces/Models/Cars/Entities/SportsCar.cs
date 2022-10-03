using System;
using System.Collections.Generic;
using System.Text;

namespace EasterRaces.Models.Cars.Entities
{
    public class SportsCar : Car
    {
        private const double DefaultCubicCentimeters = 3000;
        private const int DefaultMinHP = 250;
        private const int DefaultMaxHP = 450;
        public SportsCar(string model, int horsePower) 
            : base(model, horsePower, DefaultCubicCentimeters, DefaultMinHP, DefaultMaxHP)
        {
        }
    }
}
