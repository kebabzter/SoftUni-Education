using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Telephony
{
    public class Smartphone : ICalling,IBrowsing
    {
        public string Browsing(string site)
        {
            if (site.Any(x=>char.IsDigit(x)))
            {
                throw new Exception("Invalid URL!");
            }
            return $"Browsing: {site}!";
        }

        public string Calling(string phoneNumber)
        {
            if (!phoneNumber.All(x => char.IsDigit(x)))
            {
                throw new Exception("Invalid number!");
            }
            return $"Calling... {phoneNumber}";
        }
    }
}
