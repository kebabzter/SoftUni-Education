using EasterRaces.Models.Cars.Contracts;
using EasterRaces.Utilities.Messages;
using System;
using System.Collections.Generic;
using System.Text;

namespace EasterRaces.Models.Cars.Entities
{
    public abstract class Car : ICar
    {
        private const int ModelMinLen = 4;

        private string model;
        private int horsePower;

        private int minHorsePower;
        private int maxHorsePower;

        protected Car(string model, int horsePower, double cubicCentimeters, int minHP, int maxHP)
        {
            minHorsePower = minHP;
            maxHorsePower = maxHP;

            Model = model;
            HorsePower = horsePower;
            CubicCentimeters = cubicCentimeters;
        }

        public string Model 
        { 
            get => model;
            private set
            {
                if (string.IsNullOrWhiteSpace(value)||value.Length<ModelMinLen)
                {
                    throw new ArgumentException(string.Format(ExceptionMessages.InvalidModel,value,ModelMinLen));
                }
                model = value;
            } 
        }

        public int HorsePower 
        { 
            get => horsePower;
            private set
            {
                if (value<minHorsePower || value>maxHorsePower)
                {
                    throw new ArgumentException(string.Format(ExceptionMessages.InvalidHorsePower,value));
                }
                horsePower = value;
            } 
        }

        public double CubicCentimeters { get; private set; }

        public double CalculateRacePoints(int laps)
        {
            return CubicCentimeters / HorsePower*laps;
        }
    }
}
