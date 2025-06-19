namespace Orama_MAUI.Pages;

public partial class PrivacyPolicyPage : ContentPage
{
    public PrivacyPolicyPage()
    {
        InitializeComponent();
    }
    private void TapGestureRecognizer_Tapped(object sender, TappedEventArgs e)
    {
        DisplayAlert("Contact us", "Navigate to gmail dashboard !", "Ok");
    }
}