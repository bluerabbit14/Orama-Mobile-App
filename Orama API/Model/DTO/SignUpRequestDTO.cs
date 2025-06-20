using Orama_API.Model.Domain;

namespace Orama_API.Model.DTO
{
    public class SignUpRequestDTO
    {
        public string Name { get; set; } 
        public string? Email { get; set; }
        public string? Phone { get; set; }
        public string Password { get; set; }
        public string Gender { get; set; } 
        public string DateOfBirth { get; set; } //ISO 8601 format (yyyy-MM-dd)
    }
}