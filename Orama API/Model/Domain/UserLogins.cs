namespace Orama_API.Model.Domain
{
    public class UserLogins
    {
        public Guid LoginId { get; set; }
        public Guid UserId { get; set; }
        public DateTime LoginTime { get; set; }
        public string? IpAddress { get; set; }
        public string? DeviceInfo { get; set; }

        public Users User { get; set; }
    }
}
