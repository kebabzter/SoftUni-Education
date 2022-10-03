using MyWebServer.Controllers;
using MyWebServer.Http;
using SMS.Data;
using SMS.Models;
using SMS.Models.Carts;
using SMS.Models.Products;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SMS.Controllers
{
    public class CartsController : Controller
    {
        private readonly SMSDbContext data;

        public CartsController(SMSDbContext data)
        {
            this.data = data;
        }

        [Authorize]
        public HttpResponse AddProduct(string productId)
        {
            var user = data.Users.FirstOrDefault(u => u.Id == this.User.Id);

            user.Cart = data.Carts.FirstOrDefault(c => c.Id == user.CartId);

            var product = data.Products.FirstOrDefault(p => p.Id == productId);

            product.Cart = user.Cart;
            product.CartId = user.CartId;

            user.Cart.Products.Add(product);

            data.SaveChanges();

            return Redirect("/Carts/Details");
        }

        [Authorize]
        public HttpResponse Details()
        {
            var user = data.Users.FirstOrDefault(u => u.Id == this.User.Id);

            var cart = data.Products
                .Where(p => p.CartId == user.CartId)
                .Select(c => new CartViewModel
                {
                    Name = c.Name,
                    Price = c.Price.ToString()
                })
                .ToList();

            return View(cart);
        }

        [Authorize]
        public HttpResponse Buy()
        {
            var user = data.Users.FirstOrDefault(u => u.Id == this.User.Id);

            user.Cart = data.Carts.FirstOrDefault(c => c.Id == user.CartId);

            user.Cart.Products.Clear();

            this.data.SaveChanges();

            return Redirect("/");
        }
    }
}
