using OnlineShop.Common.Constants;
using OnlineShop.Models.Products.Components;
using OnlineShop.Models.Products.Computers;
using OnlineShop.Models.Products.Peripherals;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OnlineShop.Core
{
    public class Controller : IController
    {
        private List<IComputer> computers;
        private List<IComponent> components;
        private List<IPeripheral> peripherals;

        public Controller()
        {
            computers = new List<IComputer>();
            components = new List<IComponent>();
            peripherals = new List<IPeripheral>();
        }

        public string AddComponent(int computerId, int id, string componentType, string manufacturer, string model, decimal price, double overallPerformance, int generation)
        {
            if (!computers.Any(x => x.Id == computerId))
            {
                throw new ArgumentException(ExceptionMessages.NotExistingComputerId);
            }
           
            IComponent componentToAdd;
            switch (componentType)
            {
                case "CentralProcessingUnit":
                    componentToAdd = new CentralProcessingUnit(id,manufacturer,model,price,overallPerformance,generation);
                    break;
                case "Motherboard":
                    componentToAdd = new Motherboard(id, manufacturer, model, price, overallPerformance, generation);
                    break;
                case "PowerSupply":
                    componentToAdd = new PowerSupply(id, manufacturer, model, price, overallPerformance, generation);
                    break;
                case "RandomAccessMemory":
                    componentToAdd = new RandomAccessMemory(id, manufacturer, model, price, overallPerformance, generation);
                    break;
                case "SolidStateDrive":
                    componentToAdd = new SolidStateDrive(id, manufacturer, model, price, overallPerformance, generation);
                    break;
                case "VideoCard":
                    componentToAdd = new VideoCard(id, manufacturer, model, price, overallPerformance, generation);
                    break;
                default:
                    throw new ArgumentException(ExceptionMessages.InvalidComponentType);
            }

            IComputer computer = computers.First(x => x.Id == computerId);
            if (computer.Components.Any(x => x.Id == id))
            {
                throw new ArgumentException(ExceptionMessages.ExistingComponentId);
            }
            computer.AddComponent(componentToAdd);
            components.Add(componentToAdd);
            return string.Format(SuccessMessages.AddedComponent,componentType,id,computerId);
        }

        public string AddComputer(string computerType, int id, string manufacturer, string model, decimal price)
        {
           
          
            if (computerType != "Laptop" && computerType != "DesktopComputer")
            {
                throw new ArgumentException(ExceptionMessages.InvalidComputerType);
            }

            IComputer computer;
            if (computerType=="Laptop")
            {
                computer = new Laptop(id, manufacturer, model, price);
            }
            else
            {
                computer = new DesktopComputer(id, manufacturer, model, price);
            }

            if (computers.Any(x => x.Id == id))
            {
                throw new ArgumentException(ExceptionMessages.ExistingComputerId);
            }
            computers.Add(computer);
            return string.Format(SuccessMessages.AddedComputer,id);
        }

        public string AddPeripheral(int computerId, int id, string peripheralType, string manufacturer, string model, decimal price, double overallPerformance, string connectionType)
        {
            if (!computers.Any(x => x.Id == computerId))
            {
                throw new ArgumentException(ExceptionMessages.NotExistingComputerId);
            }

            IPeripheral peripheralToAdd;
            switch (peripheralType)
            {
                case "Headset":
                    peripheralToAdd = new Headset(id, manufacturer, model, price, overallPerformance,connectionType);
                    break;
                case "Keyboard":
                    peripheralToAdd = new Keyboard(id, manufacturer, model, price, overallPerformance, connectionType);
                    break;
                case "Monitor":
                    peripheralToAdd = new Monitor(id, manufacturer, model, price, overallPerformance, connectionType);
                    break;
                case "Mouse":
                    peripheralToAdd = new Mouse(id, manufacturer, model, price, overallPerformance, connectionType);
                    break;
                default:
                    throw new ArgumentException(ExceptionMessages.InvalidPeripheralType);
            }

            IComputer computer = computers.First(x => x.Id == computerId);
            if (computer.Peripherals.Any(x => x.Id == id))
            {
                throw new ArgumentException(ExceptionMessages.ExistingPeripheralId);
            }
            computer.AddPeripheral(peripheralToAdd);
            peripherals.Add(peripheralToAdd);
            return string.Format(SuccessMessages.AddedPeripheral, peripheralType , id, computerId);
        }

        public string BuyBest(decimal budget)
        {
            IComputer computer = computers
               .Where(c => c.Price <= budget)
               .OrderByDescending(c => c.OverallPerformance)
               .FirstOrDefault();

            if (computer is null)
            {
                throw new ArgumentException(string.Format(ExceptionMessages.CanNotBuyComputer, budget));
            }

            this.computers.Remove(computer);
            return computer.ToString();
        }

        public string BuyComputer(int id)
        {
            if (!computers.Any(x => x.Id == id))
            {
                throw new ArgumentException(ExceptionMessages.NotExistingComputerId);
            }

            IComputer computer = computers.First(x => x.Id == id);
            computers.Remove(computer);
            return computer.ToString();
        }

        public string GetComputerData(int id)
        {
            if (!computers.Any(x => x.Id == id))
            {
                throw new ArgumentException(ExceptionMessages.NotExistingComputerId);
            }

            IComputer computer = computers.First(x => x.Id == id);
            return computer.ToString();
        }

        public string RemoveComponent(string componentType, int computerId)
        {
            if (!computers.Any(x => x.Id == computerId))
            {
                throw new ArgumentException(ExceptionMessages.NotExistingComputerId);
            }

            IComputer computer = computers.First(x => x.Id == computerId);
            computer.RemoveComponent(componentType);

            IComponent component = components.First(c => c.GetType().Name == componentType);

            components.Remove(component);
            return string.Format(SuccessMessages.RemovedComponent, componentType, component.Id);
        }

        public string RemovePeripheral(string peripheralType, int computerId)
        {
            if (!computers.Any(x => x.Id == computerId))
            {
                throw new ArgumentException(ExceptionMessages.NotExistingComputerId);
            }

            IComputer computer = computers.First(x => x.Id == computerId);
            computer.RemovePeripheral(peripheralType);

            IPeripheral peripheral = peripherals.First(c => c.GetType().Name == peripheralType);

            peripherals.Remove(peripheral);
            return string.Format(SuccessMessages.RemovedPeripheral, peripheralType, peripheral.Id);
        }
    }
}
