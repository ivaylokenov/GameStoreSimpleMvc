namespace GameStore.App.Services
{
    using Contracts;
    using Data;
    using Data.Models;
    using System.Linq;

    public class UserService : IUserService
    {
        private readonly GameStoreDbContext db;

        public UserService(GameStoreDbContext db)
        {
            this.db = db;
        }

        public bool Create(string email, string password, string name)
        {
            if (this.db.Users.Any(u => u.Email == email))
            {
                return false;
            }

            var isAdmin = !db.Users.Any();

            var user = new User
            {
                Email = email,
                Name = name,
                Password = password,
                IsAdmin = isAdmin
            };

            db.Add(user);
            db.SaveChanges();

            return true;
        }

        public bool UserExists(string email, string password)
            => this.db
                .Users
                .Any(u => u.Email == email && u.Password == password);
    }
}
