namespace Orama_MAUI.Pages;

public partial class ForgotPasswordPage : ContentPage
{
    public ForgotPasswordPage()
    {
        InitializeComponent();
    }

    private void Login_Tapped(object sender, TappedEventArgs e)
    {
        Application.Current.MainPage = new NavigationPage(new LoginPage());
    }
    private void Contactus_Tapped(object sender, TappedEventArgs e)
    {
        Navigation.PushAsync(new ContactUsPage());
    }

    private void Button_Clicked(object sender, EventArgs e)
    {
        DisplayAlert("Forgot Password", "will config later", "Ok");
    }

    private void VerifyButton_Clicked(object sender, EventArgs e)
    {
        string IdValue = IdEntry.Text?.Trim();
        if (string.IsNullOrWhiteSpace(IdValue))
        {
            IdEntryFrame.BorderColor = Colors.Red;
            DisplayAlert("Forgot Password", "Email cannot be an empty field", "ok");
            return;
        }
        if (!string.IsNullOrWhiteSpace(IdValue))
        {
            IdEntryFrame.BorderColor = Colors.Gray;
        }

        if (IdValue.Contains("@") && IdValue.Contains(".") || IdValue.Length == 10 && IdValue.All(char.IsDigit))
        {
            //API Integretion will be done here !! 
            //First It check email/number is registered or not
            //Second it will send a OTP to the particular email/number


            DisplayAlert("Forgot Password", $"OTP is send to {IdValue}.\nIt is Valid for 5 min", "Ok");
        }
        else
        {
            DisplayAlert("Forgot Password", $"{IdValue} is neither a Email Address nor a phone number", "Ok");
        }
    }
}