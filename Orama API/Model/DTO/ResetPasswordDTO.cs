namespace Orama_API.Model.DTO
{
    public class ResetPasswordDTO
    {
        public string TokenOrOtp { get; set; } = string.Empty; // Depending on your reset logic
        public string NewPassword { get; set; } = string.Empty;
    }
}
