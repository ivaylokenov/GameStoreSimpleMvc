namespace GameStore.App.Models.Users
{
    using Infrastructure.Validation;

    public class LoginModel
    {
        [Required]
        public string Email { get; set; }

        [Required]
        public string Password { get; set; }
    }
}
