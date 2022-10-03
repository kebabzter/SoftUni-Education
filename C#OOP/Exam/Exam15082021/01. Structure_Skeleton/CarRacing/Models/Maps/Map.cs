using CarRacing.Models.Maps.Contracts;
using CarRacing.Models.Racers.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace CarRacing.Models.Maps
{
    public class Map : IMap
    {
        public string StartRace(IRacer racerOne, IRacer racerTwo)
        {
            if (!racerOne.IsAvailable() && !racerTwo.IsAvailable())
            {
                return "Race cannot be completed because both racers are not available!";
            }

            if (!racerOne.IsAvailable())
            {
                return $"{racerTwo.Username} wins the race! {racerOne.Username} was not available to race!";
            }

            if (!racerTwo.IsAvailable())
            {
                return $"{racerOne.Username} wins the race! {racerTwo.Username} was not available to race!";
            }

            racerOne.Race();
            racerTwo.Race();

            double oneR;
            double twoR;
            if (racerOne.RacingBehavior == "strict")
            {
                oneR = racerOne.Car.HorsePower * racerOne.DrivingExperience*1.2;
            }
            else
            {
                oneR = racerOne.Car.HorsePower * racerOne.DrivingExperience*1.1;
            }

            if (racerTwo.RacingBehavior == "strict")
            {
                twoR = racerTwo.Car.HorsePower * racerTwo.DrivingExperience* 1.2;
            }
            else
            {
                twoR = racerTwo.Car.HorsePower * racerTwo.DrivingExperience* 1.1;
            }

            if (oneR > twoR)
            {
                return $"{racerOne.Username} has just raced against {racerTwo.Username}! {racerOne.Username} is the winner!";
            }
            else
            {
                return $"{racerOne.Username} has just raced against {racerTwo.Username}! {racerTwo.Username} is the winner!";
            }

        }
    }
}
