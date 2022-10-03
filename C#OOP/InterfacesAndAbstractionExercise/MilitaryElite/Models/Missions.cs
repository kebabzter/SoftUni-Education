using MilitaryElite.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace MilitaryElite.Models
{
    public class Missions : IMissions
    {
        public Missions(string codeName, MissionState stateMission)
        {
            CodeName = codeName;
            StateMission = stateMission;
        }

        public string CodeName { get; }

        public MissionState StateMission { get; private set; }

        public void CompleteMission()
        {
            StateMission = MissionState.Finished;
        }

        public override string ToString()
        {
            return $"Code Name: {CodeName} State: {StateMission}";
        }
    }
}
