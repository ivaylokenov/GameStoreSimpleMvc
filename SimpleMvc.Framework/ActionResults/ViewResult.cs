namespace SimpleMvc.Framework.ActionResults
{
    using Contracts;
    using WebServer.Enums;
    using WebServer.Http.Contracts;
    using WebServer.Http.Response;

    public class ViewResult : IViewable
    {
        public ViewResult(IRenderable view)
        {
            this.View = view;
        }

        public IRenderable View { get; set; }

        public IHttpResponse Invoke() 
            => new ContentResponse(
                HttpStatusCode.Ok, 
                this.View.Render());
    }
}
