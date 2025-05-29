using System.Threading.Tasks;

namespace Orama_MAUI.Pages;

public partial class SignupPage : ContentPage
{
    public SignupPage()
    {
        InitializeComponent();
    }

    private async void TapGestureRecognizer_Tapped(object sender, TappedEventArgs e)
    {
        await DisplayAlert("Contact us", "will config later", "OK");
    }

    private async void TapGestureRecognizer_Tapped_1(object sender, TappedEventArgs e)
    {
        await Navigation.PushAsync(new LoginPage());
    }

    private void Button_Clicked(object sender, EventArgs e)
    {
        DisplayAlert("Alert", "will config later", "OK");
    }

    private void Button_Clicked_1(object sender, EventArgs e)
    {
        DisplayAlert("Alert", "will config later", "OK");
    }
}