using System;
using System.Collections.Generic;
using System.Text;

namespace MilitaryElite.Interfaces
{
    public interface IMissions
    {
        public string CodeName { get; }
        public MissionState StateMission { get; }

        public void CompleteMission();
    }
}
