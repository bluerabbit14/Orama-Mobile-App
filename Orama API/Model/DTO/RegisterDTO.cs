namespace Orama_API.Model.DTO
{
    public class RegisterDTO
    {
        public string? Email { get; set; } = string.Empty;
        public string? Phone { get; set; } = string.Empty;
        public string PasswordHash { get; set; } = string.Empty;
    }
}
