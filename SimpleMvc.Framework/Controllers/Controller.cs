namespace SimpleMvc.Framework.Controllers
{
    using ActionResults;
    using Attributes.Validation;
    using Contracts;
    using Helpers;
    using Models;
    using Security;
    using System.Linq;
    using System.Reflection;
    using System.Runtime.CompilerServices;
    using ViewEngine;
    using WebServer.Http;
    using WebServer.Http.Contracts;

    public abstract class Controller
    {
        public Controller()
        {
            this.ViewModel = new ViewModel();
            this.User = new Authentication();
        }

        protected ViewModel ViewModel { get; private set; }

        protected internal IHttpRequest Request { get; internal set; }

        protected internal Authentication User { get; private set; }

        protected IViewable View([CallerMemberName]string caller = "")
        {
            var controllerName = ControllerHelpers.GetControllerName(this);

            var viewFullQualifiedName = ControllerHelpers
                .GetViewFullQualifiedName(controllerName, caller);

            var view = new View(viewFullQualifiedName, this.ViewModel.Data);

            return new ViewResult(view);
        }

        protected IRedirectable Redirect(string redirectUrl)
            => new RedirectResult(redirectUrl);

        protected IActionResult NotFound()
            => new NotFoundResult();

        protected bool IsValidModel(object model)
        {
            var properties = model.GetType().GetProperties();

            foreach (var property in properties)
            {
                var attributes = property
                    .GetCustomAttributes()
                    .Where(a => a is PropertyValidationAttribute)
                    .Cast<PropertyValidationAttribute>();
                
                foreach (var attribute in attributes)
                {
                    var propertyValue = property.GetValue(model);

                    if (!attribute.IsValid(propertyValue))
                    {
                        return false;
                    }
                }
            }

            return true;
        }

        protected void SignIn(string name)
        {
            this.Request.Session.Add(SessionStore.CurrentUserKey, name);
        }

        protected void SignOut()
        {
            this.Request.Session.Remove(SessionStore.CurrentUserKey);
        }

        protected internal virtual void InitializeController()
        {
            var user = this.Request
                .Session
                .Get<string>(SessionStore.CurrentUserKey);

            if (user != null)
            {
                this.User = new Authentication(user);
            }
        }
    }
}
