using System;
using System.Collections.Generic;
using System.Linq;

namespace SoftUniKaraoke
{
    class Program
    {
        static void Main(string[] args)
        {
            List<string> participants = Console.ReadLine()
                .Split(", ",StringSplitOptions.RemoveEmptyEntries)
                .ToList();
            List<string> songs = Console.ReadLine()
                .Split(", ",StringSplitOptions.RemoveEmptyEntries)
                .ToList();
            Dictionary<string, List<string>> karaoke = new Dictionary<string, List<string>>();
            while (true)
            {
                string input = Console.ReadLine();
                if (input=="dawn")
                {
                    break;
                }
            
                string[] currentInfo = input.Split(", ",StringSplitOptions.RemoveEmptyEntries);
                string participant = currentInfo[0];
                string song = currentInfo[1];
                string award = currentInfo[2];

                if (participants.Contains(participant)&&songs.Contains(song))
                {
                    if (karaoke.ContainsKey(participant))
                    {
                        if (!karaoke[participant].Contains(award))
                        {
                            karaoke[participant].Add(award);
                        }
                    }
                    else
                    {
                        karaoke.Add(participant, new List<string>());
                        karaoke[participant].Add(award);
                    }
                }
            }
            if (karaoke.Count==0)
            {
                Console.WriteLine("No awards");
            }
            else
            {
                foreach (var item in karaoke.OrderByDescending(x=>x.Value.Count).ThenBy(x=>x.Key))
                {
                    Console.WriteLine($"{item.Key}: {item.Value.Count} awards");
                    foreach (var currentAward in item.Value.OrderBy(x=>x))
                    {
                        Console.WriteLine($"--{currentAward}");
                    }

                }
            }
        }
    }
}
