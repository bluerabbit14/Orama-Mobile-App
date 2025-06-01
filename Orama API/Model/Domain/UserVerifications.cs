namespace Orama_API.Model.Domain
{
    public class UserVerifications
    {
        public Guid VerificationId { get; set; }
        public Guid UserId { get; set; }

        public string ContactType { get; set; } // "Email" or "Phone"
        public string? ContactValue { get; set; }
        public string? VerificationCode { get; set; } // Token or OTP

        public string? CodeType { get; set; } // "Token" or "OTP"
        public string Purpose { get; set; } // "AccountVerification" or "PasswordReset"

        public DateTime? ExpiresAt { get; set; }
        public bool? IsUsed { get; set; }
        public DateTime CreatedAt { get; set; }

        public Users User { get; set; }
    }
}
