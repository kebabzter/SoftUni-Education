using CarShop.Data;
using CarShop.Data.Models;
using CarShop.Models.Cars;
using CarShop.Services;
using MyWebServer.Controllers;
using MyWebServer.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarShop.Controllers
{
    public class CarsController : Controller
    {
        private readonly CarShopDbContext data;
        private readonly IValidator validator;

        public CarsController(CarShopDbContext data, IValidator validator)
        {
            this.validator = validator;
            this.data = data;
        }

        public CarsController(CarShopDbContext data) => this.data = data;

        [Authorize]
        public HttpResponse All()
        {
            var carsQuery = this.data
                .Cars
                .AsQueryable();

            if (this.UserIsMechanic())
            {
                carsQuery = carsQuery
                    .Where(c => c.Issues.Any(i => !i.IsFixed));
            }
            else
            {
                carsQuery = carsQuery
                    .Where(c => c.OwnerId == this.User.Id);
            }
        }

        [Authorize]
        public HttpResponse Add()
        {
            if (!this.UserIsMechanic())
            {
                return Error("Mechanics cannot add cars.");
            }

            return View();
        }

        [Authorize]
        [HttpPost]
        public HttpResponse Add(AddCarFormModel model)
        {
            var modelErrors = this.validator.ValidateCar(model);

            if (modelErrors.Any())
            {
                return Error(modelErrors);
            }

            var car = new Car
            {
                Model = model.Model,
                Year = model.Year,
                PictureUrl = model.Image,
                PlateNumber = model.PlateNumber,
                OwnerId = this.User.Id,
            };

            data.Cars.Add(car);

            data.SaveChanges();

            return Redirect("/Cars/All");
        }

        private bool UserIsMechanic()
            => this.data
                .Users
                .Any(u => u.Id == this.User.Id && u.IsMechanic);
    }
}
