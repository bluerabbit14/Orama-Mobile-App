using System.Data;

namespace Orama_API.Model.Domain
{
    public class Users
    {
        public Guid UserId { get; set; }
        public string? Email { get; set; }
        public string? Phone { get; set; }
        public string? UserName { get; set; }
        public string PasswordHash { get; set; }
        public bool? IsEmailVerified { get; set; }
        public bool? IsPhoneVerified { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime LastUpdated { get; set; }
        public bool IsActive { get; set; } = true;

        public int? RoleId { get; set; }
        public Roles Role { get; set; }

        public ICollection<UserLogins> UserLogins { get; set; }
        public ICollection<UserVerifications> UserVerifications { get; set; }
        public ICollection<PasswordResetTokens> PasswordResetTokens { get; set; }

    }
}
