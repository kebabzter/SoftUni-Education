using MyWebServer.Controllers;
using MyWebServer.Http;
using SharedTrip.Data;
using SharedTrip.Data.Models;
using SharedTrip.Models.Trips;
using SharedTrip.Services;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SharedTrip.Controllers
{
    using static DataConstants;
    public class TripsController : Controller
    {
        private readonly ApplicationDbContext data;
        private readonly IValidator validator;

        public TripsController(
            ApplicationDbContext data,
            IValidator validator)
        {
            this.data = data;
            this.validator = validator;
        }

        [Authorize]
        public HttpResponse All()
        {


            var tripsQuery = this.data
                .Trips
                .AsQueryable();

            var trips = tripsQuery
                .Select(t => new TripListingViewModel
                {
                    Id = t.Id,
                    StartPoint = t.StartPoint,
                    EndPoint = t.EndPoint,
                    DepartureTime = t.DepartureTime.ToString(DateTimeFormat),
                    Seats = t.Seats,
                    Description = t.Description
                })
                .ToList();

            return View(trips);
        }

        [Authorize]
        public HttpResponse Add() => View();

        [HttpPost]
        [Authorize]
        public HttpResponse Add(AddTripFormModel model)
        {
            bool isDateValid = DateTime.TryParseExact(
                model.DepartureTime,
                DateTimeFormat,
                CultureInfo.InvariantCulture,
                DateTimeStyles.None,
                out DateTime departureTime);

            var modelErrors = this.validator.ValidateTrip(model, isDateValid);

            if (modelErrors.Any())
            {
                return Error(modelErrors);
            }


            var trip = new Trip
            {
                StartPoint = model.StartPoint,
                EndPoint = model.EndPoint,
                ImagePath = model.ImagePath,
                DepartureTime = departureTime,
                Seats = model.Seats,
                Description = model.Description
            };

      

           

            this.data.Trips.Add(trip);

            this.data.SaveChanges();

            return Redirect("/Trips/All");

        }

        [Authorize]
        public HttpResponse Details(string tripId)
        {
            DetailsListingViewModel trip = this.data
                 .Trips
                 .Where(t => t.Id == tripId)
                 .Select(t => new DetailsListingViewModel
                 {
                     Id = t.Id,
                     StartPoint = t.StartPoint,
                     EndPoint = t.EndPoint,
                     DepartureTime = t.DepartureTime.ToString(DateTimeFormat),
                     ImagePath = t.ImagePath,
                     Seats = t.Seats,
                     Description = t.Description
                 }).FirstOrDefault();


            return View(trip);
        }

        [Authorize]
        public HttpResponse AddUserToTrip(string tripId)
        {
            var user = data.Users.FirstOrDefault(u => u.Id == this.User.Id);
            var trip = data.Trips.FirstOrDefault(t => t.Id == tripId);
            try
            {
                var userTrip = new UserTrip
                {
                    TripId = tripId,
                    Trip = trip,
                    User = user,
                    UserId = this.User.Id
                };
                if (data.UserTrips.Contains(userTrip))
                {
                    throw new InvalidOperationException();
                }
                data.UserTrips.Add(userTrip);

                data.SaveChanges();
            }
            catch (InvalidOperationException)
            {
                return Redirect($"/Trips/Details?tripId={tripId}");
            }

            if (trip.Seats < 1)
            {
                return Error("No seats available");
            }

            trip.Seats--;

            data.SaveChanges();

            return Redirect("/Trips/All");
        }

    }
}
