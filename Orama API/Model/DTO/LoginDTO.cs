namespace Orama_API.Model.DTO
{
    public class LoginDTO
    {
        public string Identifier { get; set; } = string.Empty; // Email or phone
        public string PasswordHash { get; set; } = string.Empty;
    }
}
