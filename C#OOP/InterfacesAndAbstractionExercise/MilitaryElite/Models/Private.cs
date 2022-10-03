﻿using MilitaryElite.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace MilitaryElite.Models
{
    public class Private : Soldier, IPrivate
    {
        public Private(int id, string firstName, string lastName,decimal salary) 
            : base(id, firstName, lastName)
        {
            Salary = salary;
        }

        public decimal Salary { get; }

        public override string ToString()
        {
            return $"{base.ToString()} Salary: {Salary:f2}";
        }
    }
}
