using Orama_MAUI.Models;
using System.Collections.ObjectModel;

namespace Orama_MAUI.Pages;

public partial class HomePage : ContentPage
{
    public ObservableCollection<CarouselItem> Items { get; set; } = new();
    public HomePage()
    {
        InitializeComponent();

        // Sample Data
        Items.Add(new CarouselItem { Value = "Slide 1" });
        Items.Add(new CarouselItem { Value = "Slide 2" });
        Items.Add(new CarouselItem { Value = "Slide 3" });

        BindingContext = this;
    }
}

public class CarouselItem
{
    public string Value { get; set; }
}
