using AquaShop.Core.Contracts;
using AquaShop.Models.Aquariums;
using AquaShop.Models.Aquariums.Contracts;
using AquaShop.Models.Decorations;
using AquaShop.Models.Decorations.Contracts;
using AquaShop.Models.Fish;
using AquaShop.Models.Fish.Contracts;
using AquaShop.Repositories;
using AquaShop.Utilities.Messages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AquaShop.Core
{
    public class Controller : IController
    {
        private DecorationRepository decorations;
        private List<IAquarium> aquariums;
        public Controller()
        {
            decorations = new DecorationRepository();
            aquariums = new List<IAquarium>();
        }
        public string AddAquarium(string aquariumType, string aquariumName)
        {
            if (aquariumType!= nameof(FreshwaterAquarium) && aquariumType!=nameof(SaltwaterAquarium))
            {
                throw new InvalidOperationException(ExceptionMessages.InvalidAquariumType);
            }
            IAquarium aquarium;
            if (aquariumType== nameof(FreshwaterAquarium))
            {
                aquarium = new FreshwaterAquarium(aquariumName);
            }
            else//SaltwaterAquarium
            {
                aquarium = new SaltwaterAquarium(aquariumName);
            }
            aquariums.Add(aquarium);
            return string.Format(OutputMessages.SuccessfullyAdded,aquariumType);
        }

        public string AddDecoration(string decorationType)
        {
            if (decorationType != nameof(Ornament) && decorationType != nameof(Plant))
            {
                throw new InvalidOperationException(ExceptionMessages.InvalidDecorationType);
            }
            IDecoration decoration;
            if (decorationType== nameof(Ornament))
            {
                decoration = new Ornament();
            }
            else
            {
                decoration = new Plant();
            }
            decorations.Add(decoration);
            return string.Format(OutputMessages.SuccessfullyAdded, decorationType);
        }

        public string AddFish(string aquariumName, string fishType, string fishName, string fishSpecies, decimal price)
        {
            if (fishType != nameof(FreshwaterFish) && fishType != nameof(SaltwaterFish))
            {
                throw new InvalidOperationException(ExceptionMessages.InvalidFishType);
            }

            IFish fish;
            IAquarium aquarium = aquariums.FirstOrDefault(x => x.Name == aquariumName);
            if (fishType == nameof(FreshwaterFish))
            {
                fish = new FreshwaterFish(fishName,fishSpecies,price);
                if (aquarium.GetType().Name !=nameof(FreshwaterAquarium))
                {
                    return OutputMessages.UnsuitableWater;
                }
            }
            else
            {
                fish = new SaltwaterFish(fishName,fishSpecies,price);
                if (aquarium.GetType().Name != nameof(SaltwaterAquarium))
                {
                    return OutputMessages.UnsuitableWater;
                }
            }

            aquarium.AddFish(fish);
                     
            return string.Format(OutputMessages.EntityAddedToAquarium,fishType,aquariumName);
        }

        public string CalculateValue(string aquariumName)
        {
            IAquarium aquarium = aquariums.FirstOrDefault(x => x.Name == aquariumName);
            decimal sum = aquarium.Fish.Sum(x => x.Price) + aquarium.Decorations.Sum(x=>x.Price);
            return string.Format(OutputMessages.AquariumValue,aquariumName,sum);
        }

        public string FeedFish(string aquariumName)
        {
            IAquarium aquarium = aquariums.FirstOrDefault(x => x.Name == aquariumName);
            aquarium.Feed();

            return string.Format(OutputMessages.FishFed,aquarium.Fish.Count);
        }

        public string InsertDecoration(string aquariumName, string decorationType)
        {
            if (!decorations.Models.Any(x=>x.GetType().Name==decorationType))
            {
                throw new InvalidOperationException(string.Format(ExceptionMessages.InexistentDecoration,decorationType));
            }

            IDecoration decoration=decorations.FindByType(decorationType);

            decorations.Remove(decoration);
            aquariums.FirstOrDefault(x => x.Name == aquariumName).AddDecoration(decoration);

            return string.Format(OutputMessages.EntityAddedToAquarium, decorationType,aquariumName);
        }

        public string Report()
        {
            StringBuilder sb = new StringBuilder();
            foreach (var aquarium in aquariums)
            {
                sb.AppendLine(aquarium.GetInfo());
            }
            return sb.ToString().TrimEnd();
        }
    }
}
