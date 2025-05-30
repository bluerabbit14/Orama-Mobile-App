namespace Orama_API.Model.DTO.UserDTO
{
    public class CreateUserDTO
    {
        public string Email { get; set; }
        public string Phone { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; } // Will be hashed before saving
        public int RoleId { get; set; }
    }
}
