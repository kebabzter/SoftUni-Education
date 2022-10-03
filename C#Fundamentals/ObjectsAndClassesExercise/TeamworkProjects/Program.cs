using System;
using System.Collections.Generic;
using System.Linq;

namespace TeamworkProjects
{
    class Program
    {
        static void Main(string[] args)
        {
            int count = int.Parse(Console.ReadLine());
            List<Team> projects = new List<Team>();
            for (int i = 0; i < count; i++)
            {
                string[] currentTeams = Console.ReadLine()
                    .Split("-",StringSplitOptions.RemoveEmptyEntries);
                string creator = currentTeams[0];
                string teamName = currentTeams[1];
                if (TeamExist(teamName,projects))
                {
                    Console.WriteLine($"Team {teamName} was already created!");
                    continue;
                }
                if (CreatorExist(creator,projects))
                {
                    Console.WriteLine($"{creator} cannot create another team!");
                    continue;
                }
                Console.WriteLine($"Team {teamName} has been created by {creator}!");
                Team team = new Team(teamName,creator);
                projects.Add(team);
            }
            while (true)
            {
                string input = Console.ReadLine();
                if (input== "end of assignment")
                {
                    break;
                }
                string[] currentUser = input.Split("->",StringSplitOptions.RemoveEmptyEntries);
                string user = currentUser[0];
                string teamUser = currentUser[1];
                if (!TeamExist(teamUser,projects))
                {
                    Console.WriteLine($"Team {teamUser} does not exist!");
                    continue;
                }
                if (CreatorExist(user,projects))
                {
                    Console.WriteLine($"Member {user} cannot join team {teamUser}!");
                    continue;
                }
                int index = projects.FindIndex(x => x.TeamName == teamUser);
                projects[index].Members.Add(user);
            }

            var disbanded = projects.OrderBy(x => x.TeamName).Where(x => x.Members.Count == 0).ToList();
            var valid = projects.OrderByDescending(x => x.Members.Count).ThenBy(x => x.TeamName).Where(x => x.Members.Count > 0).ToList();

            foreach (var item in valid)
            {
                Console.WriteLine(item.TeamName);
                Console.WriteLine($"- {item.Creator}");
                foreach (var users in item.Members.OrderBy(x=>x))
                {
                    Console.WriteLine($"-- {users}");
                }
            }
            Console.WriteLine($"Teams to disband:");
            foreach (var item in disbanded)
            {
                Console.WriteLine(item.TeamName);
            }
        }

        public static bool TeamExist(string teamName,List<Team> teamList)
        {
            if (teamList.Select(x=>x.TeamName).Contains(teamName))
            {
                return true;
            }
            return false;
        }

        public static bool CreatorExist(string creatorName, List<Team> teamList)
        {
            if (teamList.Select(x => x.Creator).Contains(creatorName))
            {
                return true;
            }
            if (teamList.Select(x => x.Members).Any(x => x.Contains(creatorName)))
            {
                return true;
            }
            return false;
        }
    }

    class Team
    {
        public string TeamName { get; set; }
        public string Creator { get; set; }
        public List<string> Members { get; set; }
        public Team(string teamName,string creator)
        {
            TeamName = teamName;
            Creator = creator;
            Members = new List<string>();
        }
    }
}
