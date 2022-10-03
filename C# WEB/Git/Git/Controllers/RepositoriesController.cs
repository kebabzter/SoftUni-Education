using Git.Data;
using Git.Data.Models;
using Git.Models.Repositories;
using Git.Services;
using MyWebServer.Controllers;
using MyWebServer.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Git.Controllers
{
    public class RepositoriesController : Controller
    {
        private readonly GitDbContext data;
        private readonly IValidator validator;

        public RepositoriesController(GitDbContext data, IValidator validator)
        {
            this.data = data;
            this.validator = validator;
        }

        [Authorize]
        public HttpResponse All()
        {
            var repositoriesQuery = this.data
                .Repositories
                .AsQueryable();

            if (this.User.IsAuthenticated)
            {
                repositoriesQuery = repositoriesQuery
                    .Where(r => r.IsPublic || r.OwnerId == this.User.Id);
            }
            else
            {
                repositoriesQuery = repositoriesQuery
                    .Where(r => r.IsPublic);
            }

            var repositories = repositoriesQuery
                .OrderByDescending(r => r.CreatedOn)
                .Select(r => new RepositoriesListingViewModel
                {
                    Id = r.Id,
                    Name = r.Name,
                    Owner = r.Owner.Username,
                    CreatedOn = r.CreatedOn.ToLocalTime().ToString("F"),
                    CommitsCount = r.Commits.Count
                })
                .ToList();

            return View(repositories);
        }

        [Authorize]
        public HttpResponse Create() => View();

        [Authorize]
        [HttpPost]
        public HttpResponse Create(RepositoryCreateFormModel model)
        {
            var modelErrors = this.validator.ValidateRepository(model);
            var user = this.data.Users.FirstOrDefault(u => u.Id == this.User.Id);

            if (modelErrors.Any())
            {
                return Error(modelErrors);
            }

            var repository = new Repository
            {
                Name = model.Name,
                OwnerId = this.User.Id,
                IsPublic = model.RepositoryType == "Public",
            };

            this.data.Repositories.Add(repository);

            this.data.SaveChanges();

            return Redirect("/Repositories/All");
        }
    }
}
