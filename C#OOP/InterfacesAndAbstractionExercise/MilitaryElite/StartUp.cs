using MilitaryElite.Interfaces;
using MilitaryElite.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace MilitaryElite
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            List<ISoldier> result = new List<ISoldier>();
            while (true)
            {
                string input = Console.ReadLine();
                if (input=="End")
                {
                    break;
                }
                string[] info = input.Split(" ", StringSplitOptions.RemoveEmptyEntries);
                string soldierType = info[0];
                int id = int.Parse(info[1]);
                string firstName = info[2];
                string lastName = info[3];
                if (soldierType=="Private")
                {
                    decimal salary = decimal.Parse(info[4]);
                    result.Add(new Private(id,firstName,lastName,salary));
                }
                else if (soldierType== "LieutenantGeneral")
                {
                    decimal salary = decimal.Parse(info[4]);
                    List<IPrivate> privates = new List<IPrivate>();
                    foreach (var item in info[5..])
                    {
                        IPrivate currentPrivate = (IPrivate)result.FirstOrDefault(x => x.Id ==int.Parse( item));
                        privates.Add(currentPrivate);
                    }
                    result.Add(new LieutenantGeneral(id,firstName,lastName,salary,privates));
                }
                else if (soldierType== "Engineer")
                {
                    decimal salary = decimal.Parse(info[4]);
                    bool validCorpE = Enum.TryParse(info[5], out Corp corp);
                    if (!validCorpE)
                    {
                        continue;
                    }
                    List<IRepair> repairs = new List<IRepair>();
                    for (int i = 0; i < info[6..].Length; i+=2)
                    {
                        var partName = info[6+i];
                        var workedHours = int.Parse(info[6+i+1]);
                        repairs.Add(new Repair(partName,workedHours));
                    }
                    result.Add(new Engineer(id,firstName,lastName,salary,corp,repairs));

                }
                else if (soldierType== "Commando")
                {
                    decimal salary = decimal.Parse(info[4]);
                    bool validCorp=Enum.TryParse(info[5], out Corp corp);
                    if (!validCorp)
                    {
                        continue;
                    }
                    List<IMissions> missions = new List<IMissions>();
                    for (int i = 6; i < info.Length; i+=2)
                    {
                        string missionName = info[i];
                        var missionState = info[i + 1];
                        bool validMission=Enum.TryParse(missionState, out MissionState state);
                        if (!validMission)
                        {
                            continue;
                        }
                        missions.Add(new Missions(missionName, state));

                    }
                    result.Add(new Commando(id, firstName,lastName,salary,corp,missions));
                }
                else if (soldierType=="Spy")
                {
                    int codeNumber = int.Parse(info[4]);
                    result.Add(new Spy(id,firstName,lastName,codeNumber));
                }
            }

            foreach (var item in result)
            {
                Console.WriteLine(item);
            }
        }
    }
}
