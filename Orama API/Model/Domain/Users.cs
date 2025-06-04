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
        public string? Role { get; set; } = "user";
        public int? SubscriptionId { get; set; }

        public Subscriptions? Subscription { get; set; }  //user can have only one subscription at a time
    }
}
