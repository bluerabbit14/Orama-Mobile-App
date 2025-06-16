
using Orama_MAUI.Models;
using SkiaSharp;
using SkiaSharp.Views.Maui;

namespace Orama_MAUI.Pages;
public partial class LoginPage : ContentPage
{
    string id = "14asifcr7@gmail.com";
    string pass = "admin@123";
    public LoginPage()
    {
        InitializeComponent();
    }
    private async void Forgotpassword_Tapped(object sender, TappedEventArgs e)
    {
        await Navigation.PushAsync(new ForgotpasswordPage());
    }
    private async void Signup_Tapped(object sender, TappedEventArgs e)
    {
        await Navigation.PushAsync(new SignupPage());
    }

    private async void LoginButton_Clicked(object sender, EventArgs e)
    {
        var login = new LoginRequest();

        string IdValue = IdEntry.Text?.Trim();
        string passwordValue = PasswordEntry.Text?.Trim();
        bool checkboxValue = Checkbox.IsChecked;

        if (string.IsNullOrWhiteSpace(IdValue))
        {
            IdEntryFrame.BorderColor = Colors.Red;
            DisplayAlert("Login", "Email/Phone cannot be an empty field", "ok");
            return;
        }
        if (!string.IsNullOrWhiteSpace(IdValue))
        {
            IdEntryFrame.BorderColor = Colors.Gray;
        }
        if (string.IsNullOrWhiteSpace(passwordValue))
        {
            passwordEntryFrame.BorderColor = Colors.Red;
            DisplayAlert("Login", "Password cannot be an empty field", "ok");
            return;
        }
        if (!string.IsNullOrWhiteSpace(passwordValue))
        {
            passwordEntryFrame.BorderColor = Colors.Gray;
        }
        if (!checkboxValue)
        {
            Checkbox.Color = Colors.Red;
            DisplayAlert("Login", "Check and Confirm you agree our terms", "ok");
            return;
        }

        if (IdValue.Contains("@") && IdValue.Contains("."))
        {
            login.Email = IdValue;
            login.Password = passwordValue;
            login.Checkbox = checkboxValue;
            //await DisplayAlert("Login", $"Email: {login.Email}\nPassword: {login.Password}\nCheckbox: {login.Checkbox}", "Ok");
        }
        else
        {
            if (IdValue.Length != 10 || !IdValue.All(char.IsDigit))
            {
                await DisplayAlert("Login", $"{IdValue} is not a proper number", "Ok");
                return;
            }
            login.Phone = IdValue;
            login.Password = passwordValue;
            login.Checkbox = checkboxValue;
            //await DisplayAlert("Login", $"Phone: {login.Phone}\nPassword: {login.Password}\nCheckbox: {login.Checkbox}", "Ok");
        }
        //API Integration will be done here !!
        //First it will check id is registed or not
        //Second it all authenticat api to login


        if (login.Email == id && login.Password == pass)
        {
            Preferences.Set("IsLoggedIn", true); // Store login status
            Preferences.Set("UserIdValue", IdValue); // Optional
            Preferences.Set("UserPassword", passwordValue); // Optional

            await DisplayAlert("Login", $"Correct Credentials", "Ok");
            Application.Current.MainPage = new AppShell();
        }
        else
        {
            await DisplayAlert("Login", $"Incorrect Credentials", "Ok");
        }
    }
    private void Contactus_Tapped(object sender, TappedEventArgs e)
    {
        Navigation.PushAsync(new ContactusPage());
    }
    private async void Terms_Policy_Tapped(object sender, TappedEventArgs e)
    {
        await Navigation.PushAsync(new PrivacypolicyPage());
    }
    private async void PrivacyPolicy_Tapped(object sender, TappedEventArgs e)
    {
        await Navigation.PushAsync(new PrivacypolicyPage());
    }
    private async void TermCondition_Tapped(object sender, TappedEventArgs e)
    {
        await Navigation.PushAsync(new TermconditionPage());
    }
    private void Checkbox_CheckedChanged(object sender, CheckedChangedEventArgs e)
    {
        bool isChecked = e.Value;
        if (isChecked)
        {
            // Checkbox is checked
            Checkbox.Color = Colors.Blue;
        }
        else
        {
            // Checkbox is unchecked
            Checkbox.Color = Colors.Red;
        }
    }
    private async void GoogleSignIn_Tapped(object sender, TappedEventArgs e)
    {
        await DisplayAlert("Login","Google SignIn Congfig later", "Ok");
    }
}
