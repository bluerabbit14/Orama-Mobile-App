namespace Orama_API.Model.DTO.PasswordResetTokenDTO
{
    public class CreatePasswordResetTokenDTO
    {
        public Guid UserId { get; set; }
        public string? Token { get; set; }
        public DateTime? ExpiresAt { get; set; }
    }
}
