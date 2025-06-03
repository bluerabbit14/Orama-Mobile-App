using Orama_MAUI.Objects;


namespace Orama_MAUI.Pages;

public partial class ForgotpasswordPage : ContentPage
{
	public ForgotpasswordPage()
	{
		InitializeComponent();
	}

    private void Login_Tapped(object sender, TappedEventArgs e)
    {
        Navigation.PushAsync(new LoginPage());
    }

    private void ConfirmButton_Clicked(object sender, EventArgs e)
    {
        var reset = new ForgotPassword();

        string emailValue = EmailEntry.Text?.Trim();
        string codeValue = CodeEntry.Text?.Trim();

        if (string.IsNullOrWhiteSpace(emailValue))
        {
            DisplayAlert("Forgot Password", "Email cannot be an empty field", "ok");
            return;
        }
        else
        {
            if (!emailValue.Contains("@"))
            {
                DisplayAlert("Forgot Password", "Enter a valid Email Address", "ok");
                return;
            }
        }
        if (string.IsNullOrWhiteSpace(codeValue))
        {
            DisplayAlert("Forgot Password", "Code is required for Email Verification", "ok");
            return;
        } 
        if (emailValue.Contains("@"))
        {
            reset.Email = emailValue;
            reset.Code = codeValue;
        }
        string message = $"Email: {reset.Email}\nCode: {reset.Code}";
        DisplayAlert("Forgot Password", message, "Ok");
    }

    private void Contactus_Tapped(object sender, TappedEventArgs e)
    {
        Navigation.PushAsync(new ContactusPage());
    }

    private void Button_Clicked(object sender, EventArgs e)
    {
        DisplayAlert("Forgot Password", "will config later", "Ok");
    }
}