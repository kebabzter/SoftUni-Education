using System;
using System.Collections.Generic;
using System.Text;

namespace CarRacing.Models.Cars
{
    public class SuperCar : Car
    {
        public SuperCar(string make, string model, string vIN, int horsePower)
            : base(make, model, vIN, horsePower, 80, 10)
        {
        }
    }
}
