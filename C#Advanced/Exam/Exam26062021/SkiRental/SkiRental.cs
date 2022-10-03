using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SkiRental
{
    public class SkiRental
    {
        private List<Ski> data;

        public SkiRental(string name, int capacity)
        {
            data = new List<Ski>();
            Name = name;
            Capacity = capacity;
        }
        public string Name { get; private set; }

        public int Capacity { get; private set; }

        public int Count => data.Count;
        public void Add(Ski ski)
        {
            if (Capacity > data.Count)
            {
                data.Add(ski);
            }
        }

        public bool Remove(string manufacturer, string model)
        {
            var info = data.FirstOrDefault(x => x.Manufacturer == manufacturer && x.Model==model);
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

        public Ski GetNewestSki()
        {
            return data.OrderByDescending(x => x.Year).FirstOrDefault();
        }

        public Ski GetSki(string manufacturer, string model)
        {
            return data.Where(x => x.Manufacturer == manufacturer && x.Model==model).FirstOrDefault();
        }

        public string GetStatistics()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"The skis stored in {Name}:");
            foreach (Ski item in data)
            {
                sb.AppendLine(item.ToString());
            }
            return sb.ToString().TrimEnd();
        }
    }
}
