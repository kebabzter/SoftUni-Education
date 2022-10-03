using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Telephony
{
    public class StationaryPhone : ICalling
    {
        public string Calling(string phoneNumber)
        {
            if (!phoneNumber.All(x=>char.IsDigit(x)))
            {
                throw new Exception("Invalid number!");
            }
            return $"Dialing... {phoneNumber}";
        }
    }
}
