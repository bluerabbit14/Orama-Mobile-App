
using Microsoft.Maui.ApplicationModel.Communication;
using Microsoft.Maui.Graphics;
using Newtonsoft.Json;
using Orama_MAUI.Models;
using Orama_MAUI.Services;
using System.Text;

namespace Orama_MAUI.Pages;
public partial class SignUpPage : ContentPage
{
    public SignUpPage()
    {
        InitializeComponent();
    }

    private void Contactus_Tapped(object sender, TappedEventArgs e)
    {
        Navigation.PushAsync(new ContactUsPage());
    }
    private void Login_Tapped(object sender, TappedEventArgs e)
    {
        Application.Current.MainPage = new NavigationPage(new LoginPage());
    }
    private void SendButton_Clicked(object sender, EventArgs e)
    {
        DisplayAlert("Sing Up", "will config later", "Ok");
    }

    private async void SignupButton_Clicked(object sender, EventArgs e)
    {
        string NameValue = NameEntry.Text?.Trim();
        string IdValue = IdEntry.Text?.Trim();
        string passwordValue = PasswordEntry1.Text?.Trim();
        string confirmPasswordValue = PasswordEntry2.Text?.Trim();
        bool checkbox = Checkbox.IsChecked;

        if (string.IsNullOrEmpty(NameValue))
        {
            NameEntryFrame.BorderColor = Colors.Red;
            DisplayAlert("Sign up", "Name is a required field", "Ok");
            return;
        }
        if (!string.IsNullOrEmpty(NameValue))
        {
            NameEntryFrame.BorderColor = Colors.Gray;
        }
        if (string.IsNullOrEmpty(IdValue))
        {
            EmailEntryFrame.BorderColor = Colors.Red;
            DisplayAlert("Sign up", "Email is a required field", "Ok");
            return;
        }
        if (!string.IsNullOrEmpty(IdValue))
        {
            EmailEntryFrame.BorderColor = Colors.Gray;
        }
        if (string.IsNullOrEmpty(passwordValue))
        {
            PasswordEntry1Frame.BorderColor = Colors.Red;
            DisplayAlert("Sign up", "Password is a required field", "Ok");
            return;
        }
        if (!string.IsNullOrEmpty(passwordValue))
        {
            PasswordEntry1Frame.BorderColor = Colors.Gray;
        }
        if (string.IsNullOrEmpty(confirmPasswordValue))
        {
            PasswordEntry2Frame.BorderColor = Colors.Red;
            DisplayAlert("Sign up", "Confirm Password is a required field", "Ok");
            return;
        }
        if (!string.IsNullOrEmpty(confirmPasswordValue))
        {
            PasswordEntry2Frame.BorderColor = Colors.Gray;
        }
        if (!passwordValue.Equals(confirmPasswordValue))
        {
            PasswordEntry1Frame.BorderColor = Colors.Red;
            PasswordEntry2Frame.BorderColor = Colors.Red;
            DisplayAlert("Sign up", "Password and Confirm Password has to match", "Ok");
            return;
        }
        if (passwordValue.Equals(confirmPasswordValue))
        {
            PasswordEntry1Frame.BorderColor = Colors.Gray;
            PasswordEntry2Frame.BorderColor = Colors.Gray;
        }

        var signup = new SignUpRequest();

        if (IdValue.Contains("@") && IdValue.Contains("."))
        {
            signup.Name = NameValue;
            signup.Email = IdValue;
            signup.Password = passwordValue;
            signup.AcceptTermsAndConditions = checkbox;
        }
        else
        {
            DisplayAlert("Sign up", "Enter a valid Email", "Ok");
            return;
        }
        //API Integration will be done here !!



        DisplayAlert("Sign up", $"Name: {signup.Name}\nEmail: {signup.Email}\nPassword: {signup.Password}", "Ok");
    }
    private void PrivacyPolicy_Tapped(object sender, TappedEventArgs e)
    {
        Navigation.PushAsync(new PrivacyPolicyPage());
    }

    private void TermCondition_Tapped(object sender, TappedEventArgs e)
    {
        Navigation.PushAsync(new TermsConditionPage());
    }
    private void Checkbox_CheckedChanged(object sender, CheckedChangedEventArgs e)
    {
        if (sender is CheckBox checkBox)
        {
            bool isChecked = e.Value;
            if (isChecked)
            {
                checkBox.Color = Application.Current.UserAppTheme == AppTheme.Dark
                    ? Colors.White
                    : Colors.Blue;
            }
            else
            {
                checkBox.Color = Colors.Red;
            }
        }
    }
}