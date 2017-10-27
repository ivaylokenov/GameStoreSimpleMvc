namespace GameStore.App.Controllers
{
    using Infrastructure;
    using Models.Home;
    using Services.Contracts;
    using SimpleMvc.Framework.Contracts;
    using System.Linq;
    using System.Text;

    public class HomeController : BaseController
    {
        private readonly IGameService games;

        public HomeController(IGameService games)
        {
            this.games = games;
        }

        public IActionResult Index()
        {
            var ownedGames = this.User.IsAuthenticated
                && this.Request.UrlParameters.ContainsKey("filter")
                && this.Request.UrlParameters["filter"] == "Owned";

            var gameCards = this.games
                .All<GameListingHomeModel>(ownedGames ? (int?)this.Profile.Id : null)
                .Select(g => g.ToHtml(this.IsAdmin))
                .ToList();

            var result = new StringBuilder();

            for (int i = 0; i < gameCards.Count; i++)
            {
                if (i % 3 == 0)
                {
                    result.Append(@"<div class=""card-group"">");
                }

                result.Append(gameCards[i]);

                if (i % 3 == 2 || i == gameCards.Count - 1)
                {
                    result.Append("</div>");
                }
            }

            this.ViewModel["games"] = result.ToString();

            return this.View();
        }
    }
}
