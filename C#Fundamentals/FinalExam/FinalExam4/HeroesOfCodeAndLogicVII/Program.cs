using System;
using System.Collections.Generic;
using System.Linq;

namespace HeroesOfCodeAndLogicVII
{
    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, int> hpHero = new Dictionary<string, int>(); 
            Dictionary<string, int> mpHero = new Dictionary<string, int>();
            int n = int.Parse(Console.ReadLine());
            for (int i = 0; i < n; i++)
            {
                string[] line = Console.ReadLine()
                    .Split(" ",StringSplitOptions.RemoveEmptyEntries);
                hpHero.Add(line[0],int.Parse(line[1]));
                mpHero.Add(line[0],int.Parse(line[2]));
            }
            while (true)
            {
                string input = Console.ReadLine();
                if (input=="End")
                {
                    break;
                }
                string[] commands = input.Split(" - ",StringSplitOptions.RemoveEmptyEntries);
                switch (commands[0])
                {
                    case "CastSpell":
                        //CastSpell – {hero name} – {MP needed} – {spell name} 
                        string nameCast = commands[1];
                        int mpNeeded = int.Parse(commands[2]);
                        string spellName = commands[3];
                        if (mpHero[nameCast]-mpNeeded>=0)
                        {
                            mpHero[nameCast] -= mpNeeded;
                            Console.WriteLine($"{nameCast} has successfully cast {spellName} and now has {mpHero[nameCast]} MP!");
                        }
                        else
                        {
                            Console.WriteLine($"{nameCast} does not have enough MP to cast {spellName}!");
                        }
                        break;
                    case "TakeDamage":
                        //TakeDamage – {hero name} – {damage} – {attacker}
                        string nameTake = commands[1];
                        int damage = int.Parse(commands[2]);
                        string attacker = commands[3];
                        if (hpHero[nameTake] - damage > 0)
                        {
                            hpHero[nameTake] -= damage;
                            Console.WriteLine($"{nameTake} was hit for {damage} HP by {attacker} and now has {hpHero[nameTake]} HP left!");
                        }
                        else
                        {
                            hpHero.Remove(nameTake);
                            mpHero.Remove(nameTake);
                            Console.WriteLine($"{nameTake} has been killed by {attacker}!");
                        }
                        break;
                    case "Recharge":
                        //Recharge – {hero name} – {amount}
                        string nameRecharge= commands[1];
                        int amount = int.Parse(commands[2]);
                        if (mpHero[nameRecharge]+amount<=200)
                        {
                            mpHero[nameRecharge] += amount;
                            Console.WriteLine($"{nameRecharge} recharged for {amount} MP!");
                        }
                        else
                        {
                            Console.WriteLine($"{nameRecharge} recharged for {200-mpHero[nameRecharge]} MP!");
                            mpHero[nameRecharge] = 200;
                        }
                        break;
                    case "Heal":
                        //Heal – {hero name} – {amount}
                        string nameHeal = commands[1];
                        int amountH = int.Parse(commands[2]);
                        if (hpHero[nameHeal] + amountH <= 100)
                        {
                            hpHero[nameHeal] += amountH;
                            Console.WriteLine($"{nameHeal} healed for {amountH} HP!");
                        }
                        else
                        {
                            Console.WriteLine($"{nameHeal} healed for {100 - hpHero[nameHeal]} HP!");
                            hpHero[nameHeal] = 100;
                        }
                        break;
                }
            }
            var sorted = hpHero
                .OrderByDescending(x => x.Value)
                .ThenBy(x => x.Key)
                .ToDictionary(x=>x.Key,x=>x.Value);
            foreach (var item in sorted)
            {
                Console.WriteLine($"{item.Key}");
                Console.WriteLine($"  HP: {item.Value}");
                Console.WriteLine($"  MP: {mpHero[item.Key]}");
            }
        }
    }
}
