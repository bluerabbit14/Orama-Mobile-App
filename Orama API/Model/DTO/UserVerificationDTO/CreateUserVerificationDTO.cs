namespace Orama_API.Model.DTO.UserVerificationDTO
{
    public class CreateUserVerificationDTO
    {
        public Guid UserId { get; set; }
        public string ContactType { get; set; } // "Email" or "Phone"
        public string ContactValue { get; set; }
        public string VerificationCode { get; set; }
        public string CodeType { get; set; } // "Token" or "OTP"
        public string Purpose { get; set; } // "AccountVerification" or "PasswordReset"
        public DateTime ExpiresAt { get; set; }
    }
}
