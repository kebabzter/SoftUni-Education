using Easter.Models.Dyes.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace Easter.Models.Dyes
{
    public class Dye : IDye
    {
        private int power;

        public Dye(int power)
        {
            Power = power;
        }

        public int Power 
        { 
            get =>power;
            private set 
            {
                if (value<0)
                {
                    power = 0;
                }
                else
                {
                    power = value;
                }
            }
        }

        public bool IsFinished()
        {
            return power == 0;
        }

        public void Use()
        {
            Power -= 10;
            if (Power<0)
            {
                Power = 0;
            }
        }
    }
}
