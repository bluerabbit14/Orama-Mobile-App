namespace Orama_API.Model.DTO.UserVerificationDTO
{
    public class UserVerificationResponseDTO
    {
        public Guid VerificationId { get; set; }
        public Guid UserId { get; set; }
        public string ContactType { get; set; }
        public string ContactValue { get; set; }
        public string CodeType { get; set; }
        public string Purpose { get; set; }
        public DateTime ExpiresAt { get; set; }
        public bool IsUsed { get; set; }
        public DateTime CreatedAt { get; set; }
    }
}
