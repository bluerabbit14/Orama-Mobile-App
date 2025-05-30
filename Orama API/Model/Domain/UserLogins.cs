

namespace Orama_API.Model.Domain
{
    public class UserLogins
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        public Guid UserId { get; set; }
        public DateTime LoginTime { get; set; } = DateTime.UtcNow;
        public string? IpAddress { get; set; }
        public string? DeviceInfo { get; set; }
    }
}
