using OnlineShop.Common.Constants;
using OnlineShop.Models.Products.Components;
using OnlineShop.Models.Products.Peripherals;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OnlineShop.Models.Products.Computers
{
    public abstract class Computer : Product, IComputer
    {
        private readonly List<IComponent> components;
        private readonly List<IPeripheral> peripherals;
        protected Computer(int id, string manufacturer, string model, decimal price, double overallPerformance) 
            : base(id, manufacturer, model, price, overallPerformance)
        {
            components = new List<IComponent>();
            peripherals = new List<IPeripheral>();
        }

        public IReadOnlyCollection<IComponent> Components => components.AsReadOnly();

        public IReadOnlyCollection<IPeripheral> Peripherals => peripherals.AsReadOnly();

        public override double OverallPerformance
        {
            get 
            {
                if (components.Count==0)
                {
                    return base.OverallPerformance;
                }
                else
                {
                    var componentsAveragePerformance = Components.Any() ? Components.Average(c => c.OverallPerformance) : 0;
                    return base.OverallPerformance + componentsAveragePerformance;
                }
            }
            
        }

        public override decimal Price
        {
            get
            {
                decimal componentsPrice = Components.Any() ? Components.Sum(c => c.Price) : 0;
                decimal peripheralsPrice = Peripherals.Any() ? Peripherals.Sum(p => p.Price) : 0;

                return base.Price + componentsPrice + peripheralsPrice;
            }
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine(base.ToString());
            sb.AppendLine($" Components ({Components.Count}):");
            foreach (var item in Components)
            {
                sb.AppendLine($"  {item}");
            }

            if (Peripherals.Any())
            {
                sb.AppendLine($" Peripherals ({Peripherals.Count}); Average Overall Performance ({Peripherals.Average(p => p.OverallPerformance):f2}):");
            }
            else
            {
                sb.AppendLine($" Peripherals ({Peripherals.Count}); Average Overall Performance (0):");
            }
                       
            foreach (var item in Peripherals)
            {
                sb.AppendLine($"  {item}");
            }
            return sb.ToString().TrimEnd();
        }

        public void AddComponent(IComponent component)
        {
            if (Components.Any(x=>x.GetType().Name==component.GetType().Name))
            {
                throw new ArgumentException(string.Format(ExceptionMessages.ExistingComponent,component.GetType().Name,GetType().Name,Id));
            }
            components.Add(component);
        }

        public void AddPeripheral(IPeripheral peripheral)
        {
            if (Peripherals.Any(x => x.GetType().Name == peripheral.GetType().Name))
            {
                throw new ArgumentException(string.Format(ExceptionMessages.ExistingPeripheral, peripheral.GetType().Name, GetType().Name, Id));
            }
            peripherals.Add(peripheral);
        }

        public IComponent RemoveComponent(string componentType)
        {
            if (Components.All(x => x.GetType().Name != componentType))
            {
                throw new ArgumentException(string.Format(ExceptionMessages.NotExistingComponent, componentType, GetType().Name, Id));
            }
            IComponent componentRemove = Components.First(x => x.GetType().Name == componentType);
            components.Remove(componentRemove);
            return componentRemove;
        }

        public IPeripheral RemovePeripheral(string peripheralType)
        {
            if (Peripherals.All(x => x.GetType().Name != peripheralType))
            {
                throw new ArgumentException(string.Format(ExceptionMessages.NotExistingPeripheral, peripheralType, GetType().Name, Id));
            }
            IPeripheral peripheralRemove = Peripherals.First(x => x.GetType().Name == peripheralType);
            peripherals.Remove(peripheralRemove);
            return peripheralRemove;
        }

        
    }
}
