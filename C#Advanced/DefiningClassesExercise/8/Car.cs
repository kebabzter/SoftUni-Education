using System;
using System.Collections.Generic;
using System.Text;

namespace CarSalesman
{
    public class Car
    {
        public Car(string model, Engine engine, string weight, string color)
        {
            Model = model;
            Engine = engine;
            Weight = weight;
            Color = color;
        }
        public string Model { get; set; }
        public Engine Engine { get; set; }

        public string Weight { get; set; }
        public string Color { get; set; }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"{Model}:");
            sb.AppendLine(Engine.ToString());
            sb.AppendLine($"  Weight: {Weight}");
            sb.AppendLine($"  Color: {Color}");

            return sb.ToString().TrimEnd();
        }
    }
}
