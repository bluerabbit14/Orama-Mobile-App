namespace Orama_API.Model.DTO.UserVerificationDTO
{
    public class UserVerificationDTO
    {
        public Guid Id { get; set; }
        public DateTime? SentAt { get; set; }
        public bool? IsVerified { get; set; }
    }
}