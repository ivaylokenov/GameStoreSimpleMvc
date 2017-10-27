namespace GameStore.App.Infrastructure
{
    using Models.Orders;
    using WebServer.Http.Contracts;

    public static class HttpSessionExtensions
    {
        private const string ShoppingCartSessionKey = "%$Shopping_Cart$%";

        public static ShoppingCart GetShoppingCart(this IHttpSession session)
        {
            var shoppingCart = session.Get<ShoppingCart>(ShoppingCartSessionKey);
            if (shoppingCart == null)
            {
                shoppingCart = new ShoppingCart();
                session.Add(ShoppingCartSessionKey, shoppingCart);
            }

            return shoppingCart;
        }
    }
}
