
namespace Orama_MAUI.Models;

internal class LoginRequest
{
    public string? Phone { get; set; }
    public bool? Checkbox { get; set; }
    public string? Email { get; set; } = string.Empty;

    public string? Password { get; set; } = string.Empty;

    public bool? RememberMe { get; set; } = false;

    public string? DeviceId { get; set; }

    public string? IPAddress { get; set; }

    public string? Location { get; set; }
    public DateTime LoginTime { get; set; } = DateTime.UtcNow;
}
