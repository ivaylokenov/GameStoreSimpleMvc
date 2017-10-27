namespace GameStore.App.Controllers
{
    using Infrastructure;
    using Models.Orders;
    using Services.Contracts;
    using SimpleMvc.Framework.Attributes.Methods;
    using SimpleMvc.Framework.Contracts;
    using System.Linq;

    public class OrdersController : BaseController
    {
        private readonly IGameService games;
        private readonly IOrderService orders;

        public OrdersController(
            IGameService games,
            IOrderService orders)
        {
            this.games = games;
            this.orders = orders;
        }

        public IActionResult Buy(int id)
        {
            if (!this.games.Exists(id))
            {
                return this.NotFound();
            }

            this.Request
                .Session
                .GetShoppingCart()
                .AddGame(id);

            return this.Redirect("/orders/cart");
        }
        
        public IActionResult Remove(int id)
        {
            this.Request
                .Session
                .GetShoppingCart()
                .RemoveGame(id);

            return this.Redirect("/orders/cart");
        }

        public IActionResult Cart()
        {
            var shoppingCart = this.Request.Session.GetShoppingCart();

            var gameIds = shoppingCart.AllGames();

            var gamesToBuy = this.games.ByIds<GameListingOrdersModel>(gameIds);

            var allGames = gamesToBuy.Select(g => g.ToHtml());
            var totalPrice = 0m;

            if (gamesToBuy.Any())
            {
                totalPrice = gamesToBuy.Sum(g => g.Price);
            }

            this.ViewModel["games"] = string.Join(string.Empty, allGames);
            this.ViewModel["total-price"] = totalPrice.ToString();

            return this.View();
        }

        [HttpPost]
        public IActionResult Finish()
        {
            if (!this.User.IsAuthenticated)
            {
                return this.RedirectToLogin();
            }

            var shoppingCart = this.Request.Session.GetShoppingCart();

            var gameIds = shoppingCart.AllGames();

            this.orders.Purchase(this.Profile.Id, gameIds);

            shoppingCart.Clear();

            return this.RedirectToHome();
        }
    }
}
