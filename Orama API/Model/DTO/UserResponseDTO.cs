namespace Orama_API.Model.DTO
{
    public class UserResponseDTO
    {
        public Guid UserId { get; set; }
        public string? Email { get; set; }
        public string? Phone { get; set; }
        public string? UserName { get; set; }
        public string? PasswordHash { get; set; } 
        public bool? IsEmailVerified { get; set; }
        public bool? IsPhoneVerified { get; set; }
        public DateTime? CreatedAt { get; set; }
        public DateTime? LastUpdated { get; set; }
        public bool? IsActive { get; set; }
        public string? Role { get; set; }
        public int? SubscriptionId { get; set; }
        public string? SubscriptionPlan { get; set; }
    }
}
