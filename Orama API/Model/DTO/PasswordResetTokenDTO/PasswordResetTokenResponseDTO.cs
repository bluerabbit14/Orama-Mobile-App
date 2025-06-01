namespace Orama_API.Model.DTO.PasswordResetTokenDTO
{
    public class PasswordResetTokenResponseDTO
    {
        public Guid ResetId { get; set; }
        public Guid UserId { get; set; }
        public string? Token { get; set; }
        public DateTime? ExpiresAt { get; set; }
        public bool? IsUsed { get; set; } = false;
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
    }
}
