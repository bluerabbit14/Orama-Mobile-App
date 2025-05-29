using System.Threading.Tasks;

namespace Orama_MAUI.Pages;

public partial class ForgotpasswordPage : ContentPage
{
	public ForgotpasswordPage()
	{
		InitializeComponent();
	}

    private async void Login_Tapped(object sender, TappedEventArgs e)
    {
        await Navigation.PushAsync(new LoginPage());
    }
    private async void TapGestureRecognizer_Tapped(object sender, TappedEventArgs e)
    {
        await DisplayAlert("Contact us", "will config later", "OK");
    }

    private void Button_Clicked(object sender, EventArgs e)
    {
        DisplayAlert("Contact us", "will config later", "OK");
    }

    private void Button_Clicked_1(object sender, EventArgs e)
    {
        DisplayAlert("Contact us", "will config later", "OK");
    }
}