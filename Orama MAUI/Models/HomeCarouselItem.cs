
namespace Orama_MAUI.Models;

public class HomeCarouselItem
{
    public string? Title { get; set; }
    public string? ImageUrl { get; set; }
    public string? Description { get; set; }
    public string? NavigateUrl { get; set; }
    public string? AltText { get; set; }
    public bool? IsVisible { get; set; } = true;
    public int? DisplayOrder { get; set; } = 0;

    public TimeSpan? DisplayDuration { get; set; }
    public string? Theme { get; set; }
    public bool? EnableAnimation { get; set; } = true;

    public DateTime? StartDate { get; set; }
    public DateTime? EndDate { get; set; }
}
