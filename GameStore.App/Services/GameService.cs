namespace GameStore.App.Services
{
    using Contracts;
    using Data;
    using Data.Models;
    using Models.Games;
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class GameService : IGameService
    {
        private readonly GameStoreDbContext db;

        public GameService(GameStoreDbContext db)
        {
            this.db = db;
        }

        public void Create(
            string title,
            string description,
            string thumbnailUrl,
            decimal price,
            double size,
            string videoId,
            DateTime releaseDate)
        {
            using (var db = new GameStoreDbContext())
            {
                var game = new Game
                {
                    Title = title,
                    Description = description,
                    Price = price,
                    Size = size,
                    ThumbnailUrl = thumbnailUrl,
                    VideoId = videoId,
                    ReleaseDate = releaseDate
                };

                db.Games.Add(game);
                db.SaveChanges();
            }
        }

        public void Update(
            int id,
            string title,
            string description,
            string thumbnailUrl,
            decimal price,
            double size,
            string videoId,
            DateTime releaseDate)
        {
            var game = this.db.Games.Find(id);

            game.Title = title;
            game.Description = description;
            game.ThumbnailUrl = thumbnailUrl;
            game.Price = price;
            game.Size = size;
            game.VideoId = videoId;
            game.ReleaseDate = releaseDate;

            this.db.SaveChanges();
        }

        public void Delete(int id)
        {
            var game = this.db.Games.Find(id);
            this.db.Games.Remove(game);

            this.db.SaveChanges();
        }

        public Game GetById(int id)
            => this.db.Games.Find(id);

        public IEnumerable<GameListingAdminModel> All()
        {
            return this.db
                .Games
                .Select(g => new GameListingAdminModel
                {
                    Id = g.Id,
                    Name = g.Title,
                    Price = g.Price,
                    Size = g.Size
                })
                .ToList();
        }
    }
}
