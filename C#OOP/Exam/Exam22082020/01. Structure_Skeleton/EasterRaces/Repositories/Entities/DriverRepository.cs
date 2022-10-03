using EasterRaces.Models.Drivers.Contracts;
using EasterRaces.Repositories.Contracts;
using EasterRaces.Utilities.Messages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EasterRaces.Repositories.Entities
{
    public class DriverRepository : IRepository<IDriver>
    {
        private readonly IDictionary<string, IDriver> driverByName;

        public DriverRepository()
        {
            driverByName = new Dictionary<string,IDriver>();
        }
        public void Add(IDriver model)
        {
            if (driverByName.ContainsKey(model.Name))
            {
                throw new ArgumentException(string.Format(ExceptionMessages.DriversExists, model.Name));
            }
            driverByName.Add(model.Name, model);
        }

        public IReadOnlyCollection<IDriver> GetAll()
        {
            return driverByName.Values.ToList();
        }

        public IDriver GetByName(string name)
        {
            IDriver driver = null;
            if (driverByName.ContainsKey(name))
            {
                driver = driverByName[name];
            }
            return driver;
        }

        public bool Remove(IDriver model)
        {
            return driverByName.Remove(model.Name);
        }
    }
}
