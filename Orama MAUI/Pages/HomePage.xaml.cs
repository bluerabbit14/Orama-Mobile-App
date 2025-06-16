using System.Collections.ObjectModel;
using System.Timers;
using Orama_MAUI.Models;

namespace Orama_MAUI.Pages;

public partial class HomePage : ContentPage
{
    public ObservableCollection<HomePageCarouselItem> Items { get; set; } = new();
    private System.Timers.Timer _carouselTimer;
    private int _currentIndex = 0;
    private bool _isUserInteracting = false;
    public HomePage()
    {
        InitializeComponent();

        Items.Add(new HomePageCarouselItem { Title="", Url="slide 1"});
        Items.Add(new HomePageCarouselItem { Title = "", Url = "slide 2" });
        Items.Add(new HomePageCarouselItem { Title = "", Url = "slide 3" });
        Items.Add(new HomePageCarouselItem { Title = "", Url = "slide 4" });
        Items.Add(new HomePageCarouselItem { Title = "", Url = "slide 5" });

        BindingContext = this;
        HomeCarousel.PositionChanged += HomeCarousel_PositionChanged;
        StartCarouselTimer();
    }
    private void StartCarouselTimer()
    {
        _carouselTimer = new System.Timers.Timer(3000);
        _carouselTimer.Elapsed += OnCarouselTimerElapsed;
        _carouselTimer.AutoReset = true;
        _carouselTimer.Enabled = true;
    }
    private void OnCarouselTimerElapsed(object sender, ElapsedEventArgs e)
    {
        if (_isUserInteracting) return;
        MainThread.BeginInvokeOnMainThread(() =>
        {
            if (Items.Count == 0)
                return;

            _currentIndex = (_currentIndex + 1) % Items.Count;
            HomeCarousel.Position = _currentIndex;
        });
    }
    private void HomeCarousel_PositionChanged(object sender, PositionChangedEventArgs e)
    {
        _isUserInteracting = true;
        _currentIndex = e.CurrentPosition;

        Device.StartTimer(TimeSpan.FromSeconds(3), () =>
        {
            _isUserInteracting = false;
            return false; // run once
        });
    }
    protected override void OnDisappearing()
    {
        base.OnDisappearing();
        _carouselTimer?.Stop();
        _carouselTimer?.Dispose();
    }
    public class HomePageCarouselItem
    {
        public string? Title { get; set; }
        public string? Url { get; set; }
    }
}