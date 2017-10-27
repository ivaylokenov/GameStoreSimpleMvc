namespace GameStore.App.Services.Contracts
{
    using System.Collections.Generic;

    public interface IOrderService
    {
        void Purchase(int userId, IEnumerable<int> gameIds);
    }
}
