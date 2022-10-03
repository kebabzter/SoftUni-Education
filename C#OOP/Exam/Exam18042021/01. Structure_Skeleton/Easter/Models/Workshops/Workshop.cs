using Easter.Models.Bunnies.Contracts;
using Easter.Models.Eggs.Contracts;
using Easter.Models.Workshops.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Easter.Models.Workshops
{
    public class Workshop : IWorkshop
    {
        public void Color(IEgg egg, IBunny bunny)
        {
            while (true)
            {
                if (bunny.Energy == 0)
                {
                    break;
                }

                if (bunny.Dyes.All(x => x.IsFinished()))
                {
                    break;
                }

                egg.GetColored();
                bunny.Work();

                while (bunny.Dyes.Any())
                {
                    if (bunny.Dyes.First().IsFinished() == false)
                    {
                        bunny.Dyes.First().Use();
                        break;
                    }

                    bunny.Dyes.Remove(bunny.Dyes.First());
                }
                if (egg.IsDone())
                {
                    break;
                }

            }

/*
            while (!egg.IsDone())
            {
                if (bunny.Energy == 0)
                {
                    break;
                }

                if (bunny.Dyes.All(x => x.IsFinished()))
                {
                    break;
                }

                egg.GetColored();
                bunny.Work(); ;
            }

*/



        }
    }
}
