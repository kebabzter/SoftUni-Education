using System;
using System.Linq;
using System.Text.RegularExpressions;

namespace NetherRealms
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] demons = Console.ReadLine()
                 .Split(new char[] {',',' ' },StringSplitOptions.RemoveEmptyEntries)
                 .OrderBy(x=>x)
                 .ToArray();
            Regex regexHealth = new Regex(@"[^\d+\-*\/.]");
            Regex regexDamage = new Regex(@"[+-]{0,1}\d+\.?\d*");
            Regex regexTotalDamage = new Regex(@"[*\/]");
            foreach (var demon in demons)
            {
                var matchHealth = regexHealth.Matches(demon);
                int health = matchHealth
                    .Select(x=>char.Parse(x.Value))
                    .Sum(x=>x);

                var matchDamage = regexDamage.Matches(demon);
                double damage = matchDamage
                    .Select(x => double.Parse(x.Value))
                    .Sum(x=>x);

                var matchTotalDamage = regexTotalDamage.Matches(demon);
                foreach (Match item in matchTotalDamage)
                {
                    if (item.Value=="*")
                    {
                        damage *= 2;
                    }
                    else
                    {
                        damage /= 2;
                    }
                }

                Console.WriteLine($"{demon} - {health} health, {damage:f2} damage");
            }

        }
    }
}
