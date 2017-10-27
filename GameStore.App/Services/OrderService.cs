namespace GameStore.App.Services
{
    using Contracts;
    using Data;
    using Data.Models;
    using System.Collections.Generic;
    using System.Linq;
    
    public class OrderService : IOrderService
    {
        private readonly GameStoreDbContext db;

        public OrderService(GameStoreDbContext db)
        {
            this.db = db;
        }

        public void Purchase(int userId, IEnumerable<int> gameIds)
        {
            var alreadyOwnedIds = this.db
                .Orders
                .Where(o => o.UserId == userId
                    && gameIds.Contains(o.GameId))
                .Select(o => o.GameId)
                .ToList();

            var newGamesIds = new List<int>(gameIds);

            foreach (var gameId in alreadyOwnedIds)
            {
                newGamesIds.Remove(gameId);
            }

            foreach (var newGameId in newGamesIds)
            {
                var order = new Order
                {
                    GameId = newGameId,
                    UserId = userId
                };

                db.Orders.Add(order);
            }

            db.SaveChanges();
        }
    }
}
