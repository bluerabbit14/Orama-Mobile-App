
using Orama_MAUI.Model;

namespace Orama_MAUI.Pages;
public partial class LoginPage : ContentPage
{
	public LoginPage()
	{
		InitializeComponent();
	}
    private void Forgotpassword_Tapped(object sender, TappedEventArgs e)
    {
        Navigation.PushAsync(new ForgotpasswordPage());
    }
    private void Signup_Tapped(object sender, TappedEventArgs e)
    {
        Navigation.PushAsync(new SignupPage());
    }

    private void LoginButton_Clicked(object sender, EventArgs e)
    {
        var login = new Login();

        string emailValue = EmailEntry.Text?.Trim();
        string passwordValue = PasswordEntry.Text?.Trim();
        bool checkboxValue = Checkbox.IsChecked;

        if(string.IsNullOrWhiteSpace(emailValue))
        {
            DisplayAlert("Login", "Email/Phone cannot be an empty field", "ok");
            return;
        }
        if(string.IsNullOrWhiteSpace(passwordValue))
        {
            DisplayAlert("Login", "Password cannot be an empty field", "ok");
            return;
        }
        if(!checkboxValue)
        {
            DisplayAlert("Login", "Check and Confirm you agree our terms", "ok");
            return;
        }

        //if user enter a string without @ it consider it as phone number value!! fix it 
        if (emailValue.Contains("@"))
        {
            login.Email = emailValue;
            login.Password = passwordValue;
            login.Checkbox = checkboxValue;
        }
        else
        {
            login.Phone = emailValue;
            login.Password = passwordValue;
            login.Checkbox = checkboxValue;
        }
        string message = $"Email: {login.Email}\nPhone: {login.Phone}\nPassword: {login.Password}\nCheckbox: {login.Checkbox}";
        DisplayAlert("Login",message, "Ok"); 
    }
    private void Contactus_Tapped(object sender, TappedEventArgs e)
    {
        Navigation.PushAsync(new ContactusPage());
    }
}