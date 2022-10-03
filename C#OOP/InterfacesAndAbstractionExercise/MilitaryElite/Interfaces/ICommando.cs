using System;
using System.Collections.Generic;
using System.Text;

namespace MilitaryElite.Interfaces
{
    public interface ICommando
    {
        public ICollection<IMissions> Missions { get; }
    }
}
