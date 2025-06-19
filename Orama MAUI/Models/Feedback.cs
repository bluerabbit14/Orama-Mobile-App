

namespace Orama_MAUI.Models;

class Feedback
{
    public string Id { get; set; } = Guid.NewGuid().ToString();
    public string? UserId { get; set; }
    public string Type { get; set; }
    public string Message { get; set; } = string.Empty;

    public int Rating { get; set; }

    public string? Email { get; set; }
    public DateTime SubmittedAt { get; set; } = DateTime.UtcNow;
}
