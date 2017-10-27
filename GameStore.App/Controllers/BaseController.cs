namespace GameStore.App.Controllers
{
    using Data;
    using Data.Models;
    using SimpleMvc.Framework.Contracts;
    using SimpleMvc.Framework.Controllers;
    using System.Linq;

    public abstract class BaseController : Controller
    {
        protected BaseController()
        {
            this.ViewModel["anonymousDisplay"] = "flex";
            this.ViewModel["userDisplay"] = "none";
            this.ViewModel["adminDisplay"] = "none";
            this.ViewModel["show-error"] = "none";
            this.ViewModel["show-success"] = "none";
        }

        protected User Profile { get; private set; }

        protected void ShowError(string error)
        {
            this.ViewModel["show-error"] = "block";
            this.ViewModel["error"] = error;
        }

        protected void ShowSuccess(string successMessage)
        {
            this.ViewModel["show-success"] = "block";
            this.ViewModel["success"] = successMessage;
        }

        protected IActionResult RedirectToHome()
            => this.Redirect("/");

        protected IActionResult RedirectToLogin()
            => this.Redirect("/users/login");

        protected override void InitializeController()
        {
            base.InitializeController();

            if (this.User.IsAuthenticated)
            {
                this.ViewModel["anonymousDisplay"] = "none";
                this.ViewModel["userDisplay"] = "flex";

                using (var db = new GameStoreDbContext())
                {
                    this.Profile = db
                        .Users
                        .First(u => u.Email == this.User.Name);

                    if (this.Profile.IsAdmin)
                    {
                        this.ViewModel["userDisplay"] = "none";
                        this.ViewModel["adminDisplay"] = "flex";
                    }
                }
            }
        }

        protected bool IsAdmin => this.User.IsAuthenticated && this.Profile.IsAdmin;
    }
}
