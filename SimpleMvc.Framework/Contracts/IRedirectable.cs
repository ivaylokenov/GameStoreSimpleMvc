namespace SimpleMvc.Framework.Contracts
{
    public interface IRedirectable : IActionResult
    {
        string RedirectUrl { get; set; }
    }
}
