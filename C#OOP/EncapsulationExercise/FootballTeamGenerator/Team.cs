using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FootballTeamGenerator
{
    public class Team
    {
        private string name;
        private List<Player> players;

        public Team(string name)
        {
            Name = name;
            players = new List<Player>();
        }
        public string  Name
        {
            get { return name; }
            private set 
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException("A name should not be empty.");
                }
                name = value;
            }
        }

        public void AddPlayer(Player player)
        {
            players.Add(player);
        }

        public void RemovePlayer(string name)
        {
            var player = players.FirstOrDefault(x=>x.Name==name);
            if (player==null)
            {
                throw new InvalidOperationException($"Player {name} is not in {Name} team.");
            }
            players.Remove(player);
        }

        public int Rating()
        {
            return players.Sum(x => x.GetSkill());
        }

        public override string ToString()
        {
            return $"{Name} - {Rating()}";
        }
    }
}
