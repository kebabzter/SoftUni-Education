using System;
using System.Collections.Generic;

namespace MinerTask
{
    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, long> miner = new Dictionary<string, long>();
            while (true)
            {
                string input = Console.ReadLine();
                if (input=="stop")
                {
                    break;
                }
                int quantity = int.Parse(Console.ReadLine());
                if (miner.ContainsKey(input))
                {
                    miner[input] += quantity;
                }
                else
                {
                    miner.Add(input,quantity);
                }
            }

            foreach (var item in miner)
            {
                Console.WriteLine($"{item.Key} -> {item.Value}");
            }
        }
    }
}
