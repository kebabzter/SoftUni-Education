using Git.Data;
using Git.Models.Commits;
using MyWebServer.Controllers;
using MyWebServer.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Git.Controllers
{
    public class CommitsController : Controller
    {
        private readonly GitDbContext data;

        public CommitsController(GitDbContext data) => this.data = data;

        [Authorize]
        public HttpResponse Create(string repositoryId)
        {
            var repository = data
                .Repositories
                .Where(r => r.Id == repositoryId)
                .Select(c => new CommitToRepositoryViewModel
                {
                    Id = c.Id,
                    Name = c.Name,
                }).FirstOrDefault();

            if (repository == null)
            {
                return BadRequest();
            }

            return View(repository);
        }

        [HttpPost]
        [Authorize]
        public HttpResponse Create(string repositoryId, CreateCommitFormModel)
        {

        }
    }
}
