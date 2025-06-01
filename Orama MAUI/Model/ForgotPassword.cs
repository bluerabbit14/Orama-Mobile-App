
namespace Orama_MAUI.Model
{
    internal class ForgotPassword
    {
        public string? Email { get; set; }
        public int? PhoneNumber { get; set; } = null;
        public string? Code { get; set; }        
    }
}
