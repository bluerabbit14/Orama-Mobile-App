namespace Orama_API.Model.DTO.UserLoginDTO
{
    public class UserLoginResponseDTO
    {
        public Guid LoginId { get; set; }
        public Guid UserId { get; set; }
        public DateTime LoginTime { get; set; }
        public string IpAddress { get; set; }
        public string DeviceInfo { get; set; }
    }
}
