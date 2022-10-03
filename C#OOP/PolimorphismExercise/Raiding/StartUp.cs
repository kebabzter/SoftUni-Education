using System;
using System.Collections.Generic;
using System.Linq;

namespace Raiding
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            List<BaseHero> heroes = new List<BaseHero>();
            while (heroes.Count!=n)
            {
                try
                {
                    string heroName = Console.ReadLine();
                    string heroType = Console.ReadLine();

                    if (heroType == "Druid")
                    {
                        heroes.Add(new Druid(heroName));
                    }
                    else if (heroType == "Paladin")
                    {
                        heroes.Add(new Paladin(heroName));
                    }
                    else if (heroType == "Rogue")
                    {
                        heroes.Add(new Rogue(heroName));
                    }
                    else if (heroType == "Warrior")
                    {
                        heroes.Add(new Warrior(heroName));
                    }
                    else
                    {
                        throw new ArgumentException("Invalid hero!");
                    }
                }
                catch (ArgumentException ae)
                {
                    Console.WriteLine(ae.Message);
                }
                
            }

            int bossPower = int.Parse(Console.ReadLine());
            foreach (var item in heroes)
            {
                Console.WriteLine(item.CastAbility());
            }

            int heroesPower = heroes.Sum(x => x.Power);
            if (heroesPower>=bossPower)
            {
                Console.WriteLine("Victory!");
            }
            else
            {
                Console.WriteLine("Defeat...");
            }
        }
    }
}
