namespace Orama_API.Model.DTO.UserDTO
{
    public class UserResponseDTO
    {
        public Guid UserId { get; set; }
        public string? Email { get; set; }
        public string? Phone { get; set; }
        public string? UserName { get; set; }
        public bool? IsEmailVerified { get; set; }=false;
        public bool? IsPhoneVerified { get; set; } = false;
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
        public bool? IsActive { get; set; } = true;
        public string? RoleName { get; set; } = null;
    }
}
