
namespace Orama_API.Model.Domain
{
    public class Users
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        public string? Email { get; set; }
        public string? Phone { get; set; }  // Supports international formats
        public string? Username { get; set; }
        public string PasswordHash { get; set; } = null!;

        public bool? IsEmailVerified { get; set; } = false;

        public bool? IsPhoneVerified { get; set; } = false;
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

        public DateTime UpdatedAt { get; set; } = DateTime.UtcNow;

        public bool IsActive { get; set; } = true;
        public string Role { get; set; } = "user";

    }
}