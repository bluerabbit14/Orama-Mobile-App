namespace Orama_API.Model.DTO
{
    public class OTPVerifyDto
    {
        public string EmailOrPhone { get; set; } = string.Empty;
        public string OtpCode { get; set; } = string.Empty;
    }
}
