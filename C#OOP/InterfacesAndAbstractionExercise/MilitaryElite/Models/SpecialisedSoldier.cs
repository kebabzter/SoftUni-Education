using MilitaryElite.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace MilitaryElite.Models
{
    public class SpecialisedSoldier : Private, ISpecialisedSoldier
    {
        public SpecialisedSoldier(int id, string firstName, string lastName, decimal salary, Corp corpSpecial) 
            : base(id, firstName, lastName, salary)
        {
            CorpSpecial = corpSpecial;
        }

        public Corp CorpSpecial { get;}

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine(base.ToString());
            sb.AppendLine($"Corps: {CorpSpecial}");
            return sb.ToString().TrimEnd();
           // return base.ToString() + Environment.NewLine + $"Corps: {CorpSpecial}";
        }
    }
}
