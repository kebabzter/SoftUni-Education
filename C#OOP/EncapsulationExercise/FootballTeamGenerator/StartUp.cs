using System;
using System.Collections.Generic;
using System.Linq;

namespace FootballTeamGenerator
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            List<Team> teams = new List<Team>();

            while (true)
            {
                var input = Console.ReadLine();
                if (input == "END")
                {
                    break;
                }

                var info = input.Split(";", StringSplitOptions.RemoveEmptyEntries);
                if (info.Length < 2) continue;

                try
                {
                    var command = info[0];
                    var teamName = info[1];

                    if (command == "Team")
                    {
                        Team currentTeam = new Team(teamName);
                        teams.Add(currentTeam);
                        continue;
                    }

                    var team = teams.FirstOrDefault(t => t.Name == teamName);
                    if (team == null)
                    {
                        Console.WriteLine($"Team {teamName} does not exist.");
                        continue;
                    }

                    switch (command)
                    {
                        case "Add":
                            string playerName = info[2];
                            int endurance = int.Parse(info[3]);
                            int sprint = int.Parse(info[4]);
                            int dribble = int.Parse(info[5]);
                            int passing = int.Parse(info[6]);
                            int shooting = int.Parse(info[7]);
                            Player currentPlayer = new Player(playerName, endurance, sprint, dribble, passing, shooting);
                            team.AddPlayer(currentPlayer);
                            break;
                        case "Remove":
                            string playerRemove = info[2];
                            team.RemovePlayer(playerRemove);
                            break;
                        case "Rating":
                            Console.WriteLine(team);
                            break;
                    }
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                }

            }
        }
    }
}

