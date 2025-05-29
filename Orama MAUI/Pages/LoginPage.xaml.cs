namespace Orama_MAUI.Pages;

public partial class LoginPage : ContentPage
{
	public LoginPage()
	{
		InitializeComponent();
	}
    private async void Forgotpassword_Tapped(object sender, TappedEventArgs e)
    {
        await Navigation.PushAsync(new ForgotpasswordPage());
        //await Shell.Current.GoToAsync(nameof(ForgotpasswordPage));
    }
    private async void Signup_Tapped(object sender, TappedEventArgs e)
    {
        await Navigation.PushAsync(new SignupPage());
        //await Shell.Current.GoToAsync(nameof(SignupPage));
    }

    private void Button_Clicked(object sender, EventArgs e)
    {
        DisplayAlert("Alert", "will config later", "OK");
    }

    private void TapGestureRecognizer_Tapped(object sender, TappedEventArgs e)
    {
        DisplayAlert("Alert", "will config later", "OK");
    }
}