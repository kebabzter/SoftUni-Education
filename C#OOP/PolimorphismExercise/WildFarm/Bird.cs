using System;
using System.Collections.Generic;
using System.Text;

namespace WildFarm
{
    public abstract class Bird:Animal
    {
        protected Bird(string name, double weight, double wingSize)
            : base(name, weight, 0)
        {
            WingSize = wingSize;
        }

        public double WingSize { get; set; }
    }
}
