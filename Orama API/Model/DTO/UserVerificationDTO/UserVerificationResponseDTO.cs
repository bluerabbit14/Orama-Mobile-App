namespace Orama_API.Model.DTO.UserVerificationDTO
{
    public class UserVerificationResponseDTO
    {
        public Guid VerificationId { get; set; }
        public Guid UserId { get; set; }
        public string ContactType { get; set; } // "Email" or "Phone"
        public string? ContactValue { get; set; }
        public string? CodeType { get; set; }
        public string Purpose { get; set; } // "AccountVerification" or "PasswordReset"
        public DateTime? ExpiresAt { get; set; }
        public bool? IsUsed { get; set; } = false;
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
    }
}
