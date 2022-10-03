using MyWebServer.Controllers;
using MyWebServer.Http;
using SMS.Data;
using SMS.Models;
using SMS.Models.Users;
using SMS.Services;
using System.Linq;

namespace SMS.Controllers
{
    public class UsersController : Controller
    {
        private readonly IValidator validator;
        private readonly IPasswordHasher passwordHasher;
        private readonly SMSDbContext data;

        public UsersController(
            IValidator validator,
            IPasswordHasher passwordHasher,
            SMSDbContext data)
        {
            this.validator = validator;
            this.passwordHasher = passwordHasher;
            this.data = data;
        }

        public HttpResponse Register() => View();

        [HttpPost]
        public HttpResponse Register(RegisterUserFormModel model)
        {
            var modelErrors = validator.ValidateUser(model);

            if (data.Users.Any(u => u.Username == model.Username))
            {
                modelErrors.Add($"User with '{model.Username}' username already exists.");
            }

            if (data.Users.Any(u => u.Email == model.Email))
            {
                modelErrors.Add($"User with '{model.Email}' e-mail already exists.");
            }

            if (modelErrors.Any())
            {
                return Error(modelErrors);
            }

            var cart = new Cart(); //create an empty Cart

            var user = new User
            {                
                Username = model.Username,
                Password = passwordHasher.HashPassword(model.Password),
                Email = model.Email,
                Cart = cart, //add cart object here
                CartId = cart.Id //taking CartId foreign key
            };

            data.Users.Add(user);
            data.SaveChanges();

            return Redirect("/Users/Login");
        }

        public HttpResponse Login() => View();

        [HttpPost]
        public HttpResponse Login(LoginUserFormModel model)
        {
            var hashedPassword = passwordHasher.HashPassword(model.Password);

            var userId = data
                .Users
                .Where(u => u.Username == model.Username && u.Password == hashedPassword)
                .Select(u => u.Id)
                .FirstOrDefault();

            if (userId == null)
            {
                return Error("Username and password combination is not valid.");
            }

            SignIn(userId);

            return Redirect("/");
        }

        [Authorize]
        public HttpResponse Logout()
        {
            SignOut();

            return Redirect("/");
        }
    }
}
