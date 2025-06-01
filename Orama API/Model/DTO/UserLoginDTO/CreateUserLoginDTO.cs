namespace Orama_API.Model.DTO.UserLoginDTO
{
    public class CreateUserLoginDTO
    {
        public Guid UserId { get; set; }
        public string? IpAddress { get; set; }
        public string? DeviceInfo { get; set; }
    }
}
