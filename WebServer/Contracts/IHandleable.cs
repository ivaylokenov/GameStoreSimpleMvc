namespace WebServer.Contracts
{
    using Http.Contracts;

    public interface IHandleable
    {
        IHttpResponse Handle(IHttpRequest request);
    }
}
