namespace FootballManager.Controllers
{
    using FootballManager.Data;
    using FootballManager.Data.Models;
    using FootballManager.Services;
    using FootballManager.ViewModels.Players;
    using MyWebServer.Controllers;
    using MyWebServer.Http;
    using System;
    using System.Linq;
    public class PlayersController : Controller
    {
        private readonly FootballManagerDbContext data;
        private readonly IValidator validator;

        public PlayersController(
            FootballManagerDbContext data,
            IValidator validator)
        {
            this.data = data;
            this.validator = validator;
        }

        [Authorize]
        public HttpResponse All()
        {
            var playersQuery = this.data
                .Players
                .AsQueryable();

            var players = playersQuery
                .Select(p => new PlayerListingViewModel
                {
                    Id = p.Id,
                    FullName = p.FullName,
                    ImageUrl = p.ImageUrl,
                    Position = p.Position,
                    Speed = p.Speed,
                    Endurance = p.Endurance,
                    Description = p.Description
                })
                .ToList();

            return View(players);
        }

        [Authorize]
        public HttpResponse Add() => View();

        [Authorize]
        [HttpPost]
        public HttpResponse Add(AddPlayerFormModel model)
        {
            var modelErrors = this.validator.ValidatePlayer(model);

            if (modelErrors.Any())
            {
                return Error(modelErrors);
            }

            var player = new Player
            {
                FullName = model.FullName,
                ImageUrl = model.ImageUrl,
                Position = model.Position,
                Speed = model.Speed,
                Endurance = model.Endurance,
                Description = model.Description
            };

            data.Players.Add(player);

            data.SaveChanges();

            return Redirect("/Players/All");
        }

        [Authorize]
        public HttpResponse Collection()
        {
            var userPlayersQuery = this.data
                .UserPlayers
                .Where(up => up.UserId == this.User.Id)
                .AsQueryable();


            var players = this.data
                .Players
                .Where(p => p.Id == userPlayersQuery.Select(up => up.PlayerId).FirstOrDefault())
                .Select(p => new PlayerListingViewModel
                {
                    Id = p.Id,
                    FullName = p.FullName,
                    ImageUrl = p.ImageUrl,
                    Position = p.Position,
                    Speed = p.Speed,
                    Endurance = p.Endurance,
                    Description = p.Description
                }).ToList();

            return View(players);
        }

        [Authorize]
        public HttpResponse AddToCollection(string playerId)
        {
            var user = data.Users.FirstOrDefault(u => u.Id == this.User.Id);
            var player = data.Players.FirstOrDefault(t => t.Id == playerId);
            try
            {
                var userPLayer = new UserPlayer
                {
                    PlayerId = playerId,
                    Player = player,
                    User = user,
                    UserId = this.User.Id
                };
                if (data.UserPlayers.Contains(userPLayer))
                {
                    throw new InvalidOperationException();
                }
                data.UserPlayers.Add(userPLayer);

                data.SaveChanges();
            }
            catch (InvalidOperationException)
            {
                return Redirect($"/Players/All");
            }

            data.SaveChanges();

            return Redirect("/Players/All");
        }

        [Authorize]
        public HttpResponse RemoveFromCollection(string playerId)
        {
            var userPlayer = data.UserPlayers.FirstOrDefault(t => t.PlayerId == playerId);

            this.data.UserPlayers.Remove(userPlayer);

            this.data.SaveChanges();

            return Redirect("/Players/Collection");
        }
    } 
}
