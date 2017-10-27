namespace GameStore.App.Services
{
    using AutoMapper.QueryableExtensions;
    using Contracts;
    using Data;
    using Data.Models;
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

            this.db.Games.Add(game);
            this.db.SaveChanges();
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

        public bool Exists(int id)
            => this.db.Games.Any(g => g.Id == id);

        public IEnumerable<TModel> ByIds<TModel>(IEnumerable<int> ids)
            => this.db
                .Games
                .Where(g => ids.Contains(g.Id))
                .ProjectTo<TModel>()
                .ToList();

        public IEnumerable<TModel> All<TModel>(int? userId = null)
        {
            var query = this.db.Games.AsQueryable();

            if (userId != null)
            {
                query = query.Where(g => g.Orders.Any(o => o.UserId == userId));
            }

            return query
                .ProjectTo<TModel>()
                .ToList();
        }
    }
}
