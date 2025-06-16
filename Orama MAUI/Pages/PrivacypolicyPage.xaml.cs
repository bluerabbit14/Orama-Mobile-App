namespace Orama_MAUI.Pages;

public partial class PrivacypolicyPage : ContentPage
{
	public PrivacypolicyPage()
	{
		InitializeComponent();
	}

    private async  void TapGestureRecognizer_Tapped(object sender, TappedEventArgs e)
    {
        await DisplayAlert("Contact us", "Navigate to gmail dashboard !", "Ok");
    }
}