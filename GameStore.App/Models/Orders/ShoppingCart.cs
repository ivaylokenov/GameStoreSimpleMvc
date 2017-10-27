namespace GameStore.App.Models.Orders
{
    using System.Collections.Generic;

    public class ShoppingCart
    {
        private readonly ICollection<int> gameIds;

        public ShoppingCart()
        {
            this.gameIds = new List<int>();
        }

        public void AddGame(int gameId)
        {
            if (!this.gameIds.Contains(gameId))
            {
                this.gameIds.Add(gameId);
            }
        }

        public void RemoveGame(int gameId) => this.gameIds.Remove(gameId);

        public IEnumerable<int> AllGames() => new List<int>(this.gameIds);

        public void Clear() => this.gameIds.Clear();
    }
}
