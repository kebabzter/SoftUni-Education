using System;
using System.Collections.Generic;
using System.Linq;

namespace MOBAChallenger
{
    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, Dictionary<string, int>> challenger = new Dictionary<string, Dictionary<string, int>>();
            while (true)
            {
                string input = Console.ReadLine();
                if (input == "Season end")
                {
                    break;
                }
                if (input.Contains("->"))
                {
                    string[] inputInfo = input.Split(" -> ", StringSplitOptions.RemoveEmptyEntries);
                    string player = inputInfo[0];
                    string position = inputInfo[1];
                    int skill = int.Parse(inputInfo[2]);
                    if (challenger.ContainsKey(player))
                    {
                        if (challenger[player].ContainsKey(position))
                        {
                            if (challenger[player][position] < skill)
                            {
                                challenger[player][position] = skill;
                            }
                        }
                        else
                        {
                            challenger[player].Add(position, skill);
                        }
                    }
                    else
                    {
                        challenger.Add(player, new Dictionary<string, int>());
                        challenger[player].Add(position, skill);
                    }
                }
                else
                {
                    string[] inputInfo = input.Split(" vs ", StringSplitOptions.RemoveEmptyEntries).ToArray();
                    string playerOne = inputInfo[0];
                    string playerTwo = inputInfo[1];
                    if (challenger.ContainsKey(playerOne) && challenger.ContainsKey(playerTwo))
                    {
                        foreach (var first in challenger[playerOne])
                        {
                            foreach (var second in challenger[playerTwo])
                            {
                                if (first.Key == second.Key)
                                {
                                    if (first.Value == second.Value)
                                    {

                                    }
                                    else if (first.Value > second.Value)
                                    {
                                        challenger[playerTwo].Remove(second.Key);
                                    }
                                    else
                                    {
                                        challenger[playerOne].Remove(first.Key);
                                    }
                                }
                            }
                        }
                    }
                }
            }

            foreach (var player in challenger.OrderByDescending(x => x.Value.Values.Sum()).ThenBy(x => x.Key))
            {
                if (player.Value.Values.Sum() > 0)
                {
                    Console.WriteLine($"{player.Key}: {player.Value.Values.Sum()} skill");

                    foreach (var position in player.Value.OrderByDescending(x => x.Value).ThenBy(x => x.Key))
                    {
                        Console.WriteLine($"- {position.Key} <::> {position.Value}");
                    }
                }
            }
        }
    }
}
