using EasterRaces.Models.Cars.Contracts;
using EasterRaces.Repositories.Contracts;
using EasterRaces.Utilities.Messages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EasterRaces.Repositories.Entities
{
    public class CarRepository : IRepository<ICar>
    {
        private readonly IDictionary<string, ICar> carByModel;

        public CarRepository()
        {
            carByModel = new Dictionary<string,ICar>();
        }
        public void Add(ICar model)
        {
            if (carByModel.ContainsKey(model.Model))
            {
                throw new ArgumentException(string.Format(ExceptionMessages.CarExists,model.Model));
            }
            carByModel.Add(model.Model,model);
        }

        public IReadOnlyCollection<ICar> GetAll()
        {
            return carByModel.Values.ToList();
        }

        public ICar GetByName(string name)
        {
            ICar car = null;
            if (carByModel.ContainsKey(name))
            {
                car = carByModel[name];
            }
            return car;
        }

        public bool Remove(ICar model)
        {
            return carByModel.Remove(model.Model);
        }
    }
}
