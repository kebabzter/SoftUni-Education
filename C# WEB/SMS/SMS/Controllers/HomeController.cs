namespace SMS.Controllers
{
    using MyWebServer.Controllers;
    using MyWebServer.Http;
    using SMS.Data;
    using SMS.Models;
    using SMS.Models.Users;
    using System.Collections.Generic;
    using System.Linq;

    public class HomeController : Controller
    {
        private readonly SMSDbContext data;

        public HomeController(SMSDbContext data)
        {
            this.data = data;
        }

        public HttpResponse Index()
        {
            if (User.IsAuthenticated)
            {
                return Redirect("/Home/IndexLoggedIn");
            }

            return View();
        }

        [Authorize]
        public HttpResponse IndexLoggedIn()
        {
            var user = data.Users.FirstOrDefault(u => u.Id == this.User.Id);

            var model = new UserViewModel
            {
                Username = user.Username,
                Products = data.Products.ToList()
            };

            return View(model);
        }
    }
}