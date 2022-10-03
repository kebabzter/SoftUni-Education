using System;
using System.Collections.Generic;
using System.Text;

namespace FoodShortage
{
    interface IBuyer:IInfo
    {
        public int Food { get; set; }

        public void BuyFood();
    }
}
