using Orama_MAUI.Models;
using Orama_MAUI.Services;
using Orama_MAUI.Constants;

namespace Orama_MAUI.Pages;

public partial class LoginPage : ContentPage
{
    public LoginPage()
    {
        InitializeComponent();
    }
    private async void Forgotpassword_Tapped(object sender, TappedEventArgs e)
    {
        await Navigation.PushAsync(new ForgotPasswordPage());
    }
    private async void Signup_Tapped(object sender, TappedEventArgs e)
    {
        await Navigation.PushAsync(new SignUpPage());
    }
    private void LoginButton_Clicked(object sender, EventArgs e)
    {
        var login = new LoginRequest();

        string IdValue = IdEntry.Text?.Trim();
        string passwordValue = PasswordEntry.Text?.Trim();
        bool checkboxValue = Checkbox.IsChecked;

        if (string.IsNullOrWhiteSpace(IdValue))
        {
            IdEntryFrame.BorderColor = Colors.Red;
            DisplayAlert("Login", "Email cannot be an empty field", "Ok");
            return;
        }
        if (!string.IsNullOrWhiteSpace(IdValue))
        {
            IdEntryFrame.BorderColor = Colors.Gray;
        }
        if (string.IsNullOrWhiteSpace(passwordValue))
        {
            passwordEntryFrame.BorderColor = Colors.Red;
            DisplayAlert("Login", "Password cannot be an empty field", "Ok");
            return;
        }
        if (!string.IsNullOrWhiteSpace(passwordValue))
        {
            passwordEntryFrame.BorderColor = Colors.Gray;
        }
        if (IdValue.Contains("@") && IdValue.Contains("."))
        {
            login.Email = IdValue;
            login.Password = passwordValue;
            login.Checkbox = checkboxValue;
        }
        else
        {
            DisplayAlert("Login", "Enter a valid Email", "Ok");
            return;
        }

        if (login.Email == Constants.Constants.IdValue && login.Password == Constants.Constants.Pass)
        {
            if (checkboxValue)
            {
                UserPreferencesService.Save("IsLoggedIn", true);
                UserPreferencesService.Save("UserIdValue", "IdValue");
                UserPreferencesService.Save("UserPassword", "passwordValue");
                Application.Current.MainPage = new AppShell();
            }
            else
                Application.Current.MainPage = new AppShell();
        }
        else
        {
            DisplayAlert("Login", "Incorrect Credentials", "Ok");
        }
    }
    private void Contactus_Tapped(object sender, TappedEventArgs e)
    {
        Navigation.PushAsync(new ContactUsPage());
    }
    private void Terms_Policy_Tapped(object sender, TappedEventArgs e)
    {
        Navigation.PushAsync(new PrivacyPolicyPage());
    }
    private void PrivacyPolicy_Tapped(object sender, TappedEventArgs e)
    {
        Navigation.PushAsync(new PrivacyPolicyPage());
    }
    private void TermCondition_Tapped(object sender, TappedEventArgs e)
    {
        Navigation.PushAsync(new TermsConditionPage());
    }
    private void GoogleSignIn_Tapped(object sender, TappedEventArgs e)
    {
        DisplayAlert("Login", "Google SignIn Congfig later", "Ok");
    }
}