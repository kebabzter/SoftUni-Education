using System;
using System.Collections.Generic;
using System.Text;

namespace WildFarm
{
    public abstract class Mammal:Animal
    {
        protected Mammal(string name, double weight,string livingRegion) 
            : base(name, weight, 0)
        {
            LivingRegion = livingRegion;
        }

        public string LivingRegion { get; set; }
    }
}
