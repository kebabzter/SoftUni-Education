using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TheRace
{
    public class Race
    {
        private List<Racer> data;
        public Race(string name, int capacity)
        {
            Name = name;
            Capacity = capacity;
            data = new List<Racer>();
        }
        public string Name { get; set; }

        public int Capacity { get; set; }

        public int Count => data.Count;

        public void Add(Racer racer)
        {
            if (Capacity>data.Count)
            {
                data.Add(racer);
            }
        }

        public bool Remove(string name)
        {
            var info = data.FirstOrDefault(x => x.Name == name);
            if (info != null)
            {
                data.Remove(info);
                return true;
            }
            else
            {
                return false;
            }
        }

        public Racer GetOldestRacer()
        {
            return data.OrderByDescending(x => x.Age).FirstOrDefault();
        }

        public Racer GetRacer(string name)
        {
            return data.Where(x => x.Name == name).FirstOrDefault();
        }

        public Racer GetFastestRacer()
        {
            return data.OrderByDescending(x => x.Car.Speed).FirstOrDefault();
        }

        public string Report()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"Racers participating at {Name}:");
            foreach (Racer item in data)
            {
                sb.AppendLine(item.ToString());
            }
            return sb.ToString().TrimEnd();
        }
    }
}
