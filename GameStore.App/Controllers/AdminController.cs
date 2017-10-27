namespace GameStore.App.Controllers
{
    using Data.Models;
    using Infrastructure;
    using Models.Games;
    using Services.Contracts;
    using SimpleMvc.Framework.Attributes.Methods;
    using SimpleMvc.Framework.Contracts;
    using System.Linq;

    public class AdminController : BaseController
    {
        public const string GameError = "<p>Check your form for errors.</p><p>Title has to begin with uppercase letter and has length between 3 and 100 symbols (inclusive).</p><p>Price must be a positive number with precision up to 2 digits after floating point.</p><p>Size must be a positive number with precision up to 1 digit after floating point.</p><p>Videos should only be from YouTube.</p><p>Thumbnail URL should be a plain text starting with http://, https://.</p><p>Description must be at least 20 symbols.</p>";

        private readonly IGameService games;

        public AdminController(IGameService games)
        {
            this.games = games;
        }

        public IActionResult Add()
        {
            if (!this.IsAdmin)
            {
                return this.RedirectToHome();
            }

            return this.View();
        }

        [HttpPost]
        public IActionResult Add(GameAdminModel model)
        {
            if (!this.IsAdmin)
            {
                return this.RedirectToHome();
            }

            if (!this.IsValidModel(model))
            {
                this.ShowError(GameError);
                return this.View();
            }

            this.games.Create(
                model.Title,
                model.Description,
                model.ThumbnailUrl,
                model.Price,
                model.Size,
                model.VideoId,
                model.ReleaseDate);

            return this.RedirectToAllGames();
        }

        public IActionResult Edit(int id)
        {
            if (!this.IsAdmin)
            {
                return this.RedirectToHome();
            }

            var game = this.games.GetById(id);

            if (game == null)
            {
                return this.NotFound();
            }

            this.SetGameViewData(game);
            
            return this.View();
        }

        [HttpPost]
        public IActionResult Edit(int id, GameAdminModel model)
        {
            if (!this.IsAdmin)
            {
                return this.RedirectToHome();
            }

            if (!this.IsValidModel(model))
            {
                this.ShowError(GameError);
                return this.View();
            }
            
            this.games.Update(
                id,
                model.Title,
                model.Description,
                model.ThumbnailUrl,
                model.Price,
                model.Size,
                model.VideoId,
                model.ReleaseDate);

            return this.RedirectToAllGames();
        }

        public IActionResult Delete(int id)
        {
            if (!this.IsAdmin)
            {
                return this.RedirectToHome();
            }

            var game = this.games.GetById(id);

            if (game == null)
            {
                return this.NotFound();
            }

            this.ViewModel["id"] = id.ToString();
            this.SetGameViewData(game);

            return this.View();
        }

        [HttpPost]
        public IActionResult Destroy(int id)
        {
            if (!this.IsAdmin)
            {
                return this.RedirectToHome();
            }

            var game = this.games.GetById(id);

            if (game == null)
            {
                return this.NotFound();
            }

            this.games.Delete(id);

            return this.RedirectToAllGames();
        }

        public IActionResult All()
        {
            if (!this.IsAdmin)
            {
                return this.RedirectToHome();
            }

            var allGames = this.games
                .All<GameListingAdminModel>()
                .Select(g => g.ToHtml());

            this.ViewModel["games"] = string.Join(string.Empty, allGames);

            return this.View();
        }

        private void SetGameViewData(Game game)
        {
            this.ViewModel["title"] = game.Title;
            this.ViewModel["description"] = game.Description;
            this.ViewModel["thumbnail"] = game.ThumbnailUrl;
            this.ViewModel["price"] = game.Price.ToString("F2");
            this.ViewModel["size"] = game.Size.ToString("F1");
            this.ViewModel["video-id"] = game.VideoId;
            this.ViewModel["release-date"] = game.ReleaseDate.ToString("yyyy-MM-dd");
        }

        private IActionResult RedirectToAllGames()
            => this.Redirect("/admin/all");
    }
}
