namespace GameStore.App.Services.Contracts
{
    public interface IUserService
    {
        bool Create(string email, string password, string name);

        bool UserExists(string email, string password);
    }
}
