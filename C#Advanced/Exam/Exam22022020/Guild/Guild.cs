using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Guild
{
    public class Guild
    {
        private List<Player> roster;

        public Guild(string name, int capacity)
        {
            Name = name;
            Capacity = capacity;
            roster = new List<Player>();
        }

        public string Name { get; private set; }

        public int Capacity { get; private set; }

        public int Count => roster.Count;
        public void AddPlayer(Player player)
        {
            if (roster.Count<Capacity&&!roster.Any(x => x.Name == player.Name))
            {
                roster.Add(player);
            }
        }

        public bool RemovePlayer(string name)
        {
            var rosterRemove = roster.FirstOrDefault(x => x.Name == name);
            if (rosterRemove==null)
            {
                return false;
            }
            roster.Remove(rosterRemove);
            return true;
        }

        public void PromotePlayer(string name)
        {
            if (roster.Any(x => x.Name == name))
            {
                roster.Where(x => x.Name == name).FirstOrDefault().Rank = "Member";
            }
        }

        public void DemotePlayer(string name)
        {
            if (roster.Any(x => x.Name == name))
            {
                roster.Where(x => x.Name == name).FirstOrDefault().Rank = "Trial";
            }
        }

        public Player[] KickPlayersByClass(string classs)
        {
            var result = roster.Where(x => x.Class == classs).ToArray();
            roster = roster.Where(x => x.Class != classs).ToList();
            return result;
        }

        public string Report()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"Players in the guild: {Name}");
            foreach (Player item in roster)
            {
                sb.AppendLine(item.ToString());
            }
            return sb.ToString().TrimEnd();

        }
    }
}
