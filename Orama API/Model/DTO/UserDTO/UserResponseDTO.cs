namespace Orama_API.Model.DTO.UserDTO
{
    public class UserResponseDTO
    {
        public Guid UserId { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public string UserName { get; set; }
        public bool IsEmailVerified { get; set; }
        public bool IsPhoneVerified { get; set; }
        public DateTime CreatedAt { get; set; }
        public bool IsActive { get; set; }
        public string RoleName { get; set; }
    }
}
