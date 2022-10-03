using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TeamworkProjects
{
    class Program
    {
        static void Main(string[] args)
        {
            int countTeams = int.Parse(Console.ReadLine());

            List<Team> teamsList = new List<Team>();
            for (int i = 0; i < countTeams; i++)
            {
                string[] info = Console.ReadLine().Split("-").ToArray();
                string person = info[0];
                string team = info[1];
                Team teams = new Team(person, team);
                if (!teamsList.Select(x => x.TeamName).Contains(team))
                {
                    if (!teamsList.Select(x => x.Creator).Contains(person))
                    {
                        teamsList.Add(teams);
                        Console.WriteLine($"Team {team} has been created by {person}!");
                    }
                    else
                    {
                        Console.WriteLine($"{person} cannot create another team!");
                    }
                }
                else
                {
                    Console.WriteLine($"Team {team} was already created!");
                }
            }
            string command = Console.ReadLine();
            while (command != "end of assignment")
            {
                string[] info = command.Split("->").ToArray();
                string person = info[0];
                string team = info[1];
                if (!teamsList.Select(x => x.TeamName).Contains(team))
                {
                    Console.WriteLine($"Team {team} does not exist!");
                }
                else if (teamsList.Select(x => x.Creator).Contains(person) || teamsList.Select(x => x.users).Any(x => x.Contains(person)))
                {
                    Console.WriteLine($"Member {person} cannot join team {team}!");
                }
                else
                {
                    int index = teamsList.FindIndex(x => x.TeamName == team);
                    teamsList[index].users.Add(person);
                }
                command = Console.ReadLine();
            }
            var disbanded = teamsList.OrderBy(x => x.TeamName).Where(x => x.users.Count == 0).ToList();
            var valid = teamsList.OrderByDescending(x => x.users.Count).ThenBy(x => x.TeamName).Where(x => x.users.Count > 0).ToList();

            foreach (var item in valid)
            {
                Console.WriteLine(item.ToString());
            }
            Console.WriteLine($"Teams to disband:");
            foreach (var item in disbanded)
            {
                Console.WriteLine(item.TeamName);
            }
        }
    }
    class Team
    {
        public string Creator { get; set; }
        public string TeamName { get; set; }
        public List<string> users;
        public Team(string creator, string teamName)
        {
            Creator = creator;
            TeamName = teamName;
            users = new List<string>();
        }
        public override string ToString()
        {
            StringBuilder text = new StringBuilder();
            text.AppendLine(TeamName);
            text.AppendLine("- " + Creator);

            foreach (var item in users.OrderBy(x => x))
            {
                text.AppendLine("-- " + item);
            }
            return text.ToString().TrimEnd();
        }
    }
}
