using MyWebServer.Controllers;
using MyWebServer.Http;
using SMS.Data;
using SMS.Models;
using SMS.Models.Products;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SMS.Controllers
{
    public class ProductsController : Controller
    {
        private readonly SMSDbContext data;

        public ProductsController(SMSDbContext data)
        {
            this.data = data;
        }

        [Authorize]
        public HttpResponse Create() => View();

        [HttpPost]
        [Authorize]
        public HttpResponse Create(CreateProductFormModel model)
        {
            var product = new Product
            {
                Name = model.Name,
                Price = decimal.Parse(model.Price),
            };

            this.data.Products.Add(product);

            this.data.SaveChanges();

            return Redirect("/");
        }

        
    }
}
