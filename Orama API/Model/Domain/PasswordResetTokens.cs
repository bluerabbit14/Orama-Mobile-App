namespace Orama_API.Model.Domain
{
        public class PasswordResetTokens
        {
            public Guid ResetId { get; set; }
            public Guid UserId { get; set; }

            public string? Token { get; set; }
            public DateTime? ExpiresAt { get; set; }
            public bool? IsUsed { get; set; }
            public DateTime CreatedAt { get; set; }

            public Users User { get; set; }
        }

}
