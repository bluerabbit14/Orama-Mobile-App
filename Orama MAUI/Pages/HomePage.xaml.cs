using AndroidX.Core.App;
using Orama_MAUI.Services;
using Orama_MAUI.ViewModels;
using System.Timers;

namespace Orama_MAUI.Pages;

public partial class HomePage : ContentPage
{
    private System.Timers.Timer _carouselTimer;
    private int _currentIndex = 0;
    private bool _isUserInteracting = false;
    private HomeViewModel _viewModel;
    public HomePage()
    {
        InitializeComponent();

        _viewModel = new HomeViewModel();
        BindingContext = _viewModel;

        HomeCarousel.PositionChanged += HomeCarousel_PositionChanged;
        StartCarouselTimer();
    }
    private void StartCarouselTimer()
    {
        _carouselTimer = new System.Timers.Timer(3000)
        {
            AutoReset = true,
            Enabled = true
        };
        _carouselTimer.Elapsed += OnCarouselTimerElapsed;
    }
    private void OnCarouselTimerElapsed(object sender, ElapsedEventArgs e)
    {
        if (_isUserInteracting || _viewModel?.CarouselItems == null || _viewModel.CarouselItems.Count == 0)
            return;

        MainThread.BeginInvokeOnMainThread(() =>
        {
            _currentIndex = (_currentIndex + 1) % _viewModel.CarouselItems.Count;
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
            return false; // only run once
        });
    }
    protected override void OnDisappearing()
    {
        base.OnDisappearing();
        _carouselTimer?.Stop();
        _carouselTimer?.Dispose();
    }
    private void SearchBar_SearchButtonPressed(object sender, EventArgs e)
    {
        DisplayAlert("Home", "will config later", "Ok");
    }
    private void SearchBar_TextChanged(object sender, TextChangedEventArgs e)
    {
        string query = e.NewTextValue;

        // TODO: Use _viewModel.FilterItems(query) or similar
        // DisplayAlert("Search Input", query, "OK");
    }

    private void TapGestureRecognizer_Tapped(object sender, TappedEventArgs e)
    {
        Navigation.PushAsync(new ChatPage());
    }
}