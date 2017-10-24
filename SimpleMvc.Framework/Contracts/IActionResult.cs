namespace SimpleMvc.Framework.Contracts
{
    using WebServer.Http.Contracts;

    public interface IActionResult
    {
        IHttpResponse Invoke();
    }
}
