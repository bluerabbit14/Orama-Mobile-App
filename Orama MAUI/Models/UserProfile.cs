
namespace Orama_MAUI.Models
{
    internal class UserProfile
    {
        public string? UserId { get; set; }

        public string? ProfileImageUrl { get; set; }

        public string? Name { get; set; }

        public string? Email { get; set; }

        public string? Phone { get; set; }

        public string? Address { get; set; }

        public string? Pincode { get; set; }

        public DateTime? DateOfBirth { get; set; }

        public Gender? Gender { get; set; }

        public string Role { get; set; } = "User";

        public DateTime Created { get; set; } = DateTime.UtcNow;
        public string? LanguagePreference { get; set; }
        public string? TimeZone { get; set; }

        public DateTime LastUpdated { get; set; } = DateTime.UtcNow;
        public bool EmailVerified { get; set; } = false;

        public bool IsActive { get; set; } = true;

        public string? Bio { get; set; }
        public string? SocialHandle { get; set; }

        public DateTime? LastLoginDate { get; set; }
    }
    public enum Gender
    {
        Male,
        Female,
        Other,
        PreferNotToSay
    }
}
