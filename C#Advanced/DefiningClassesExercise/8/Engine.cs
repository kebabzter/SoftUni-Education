using System;
using System.Collections.Generic;
using System.Text;

namespace CarSalesman
{
    public class Engine
    {
        public Engine(string model, string power, string displacement, string efficiency)
        {
            Model = model;
            Power = power;
            Displacement = displacement;
            Efficiency = efficiency;
        }
        public string Model { get; set; }
        public string Power { get; set; }

        public string Displacement { get; set; }

        public string Efficiency { get; set; }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"  {Model}:");
            sb.AppendLine($"    Power: {Power}");
            sb.AppendLine($"    Displacement: {Displacement}");
            sb.AppendLine($"    Efficiency: {Efficiency}");

            return sb.ToString().TrimEnd();
        }
    }
}
