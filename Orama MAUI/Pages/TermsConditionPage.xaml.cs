using Orama_MAUI.Services;

namespace Orama_MAUI.Pages;

public partial class TermsConditionPage : ContentPage
{
    public TermsConditionPage()
    {
        InitializeComponent();
    }

    private async void TapGestureRecognizer_Tapped(object sender, TappedEventArgs e)
    {
        DisplayAlert("Contact us", "Navigate to gmail dashboard !", "Ok");
    }
}