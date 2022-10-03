using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SharedTrip.Models.Trips
{
    public class AddTripFormModel
    {
        public string StartPoint { get; init; }

        public string EndPoint { get; init; }

        public string DepartureTime { get; init; }

        public int Seats { get; init; }

        public string Description { get; init; }

        public string ImagePath { get; init; }
    }
}
