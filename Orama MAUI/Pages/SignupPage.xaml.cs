
using Microsoft.Maui.ApplicationModel.Communication;
using Microsoft.Maui.Graphics;
using Newtonsoft.Json;
using Orama_MAUI.Models;
using System.Text;

namespace Orama_MAUI.Pages;
public partial class SignupPage : ContentPage
{
    public SignupPage()
    {
        InitializeComponent();
    }

    private void Contactus_Tapped(object sender, TappedEventArgs e)
    {
        Navigation.PushAsync(new ContactusPage());
    }
    private void Login_Tapped(object sender, TappedEventArgs e)
    {
        Application.Current.MainPage = new NavigationPage(new LoginPage());
    }
    private void SendButton_Clicked(object sender, EventArgs e)
    {
        DisplayAlert("Sing Up", "will config later", "OK");
    }

    private async void SignupButton_Clicked(object sender, EventArgs e)
    {
        string IdValue = IdEntry.Text?.Trim();
        string passwordValue = PasswordEntry1.Text?.Trim();
        string confirmPasswordValue = PasswordEntry2.Text?.Trim();
        bool checkbox = Checkbox.IsChecked;

        if (string.IsNullOrEmpty(IdValue))
        {
            EmailEntryFrame.BorderColor = Colors.Red;
            await DisplayAlert("Sign up", "Email is a required field", "OK");
            return;
        }
        if(!string.IsNullOrEmpty(IdValue))
        {
            EmailEntryFrame.BorderColor = Colors.Gray;
        }
        if (string.IsNullOrEmpty(passwordValue))
        {
            PasswordEntry1Frame.BorderColor = Colors.Red;
            await DisplayAlert("Sign up", "Password is a required field", "OK");
            return;
        }
        if (!string.IsNullOrEmpty(passwordValue))
        {
            PasswordEntry1Frame.BorderColor = Colors.Gray;
        }
        if (string.IsNullOrEmpty(confirmPasswordValue))
        {
            PasswordEntry2Frame.BorderColor = Colors.Red;
            await DisplayAlert("Sign up", "Confirm Password is a required field", "OK");
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
            await DisplayAlert("Sign up", "Password and Confirm Password has to match", "OK");
            return;
        }
        if (passwordValue.Equals(confirmPasswordValue))
        {
            PasswordEntry1Frame.BorderColor = Colors.Gray;
            PasswordEntry2Frame.BorderColor = Colors.Gray;
        }

        var signup = new SignupRequest();
                               
        if (IdValue.Contains("@") && IdValue.Contains("."))
        {
            signup.Email = IdValue;
            signup.Password = passwordValue;
            signup.CheckBox = checkbox;
        }
        else
        {
            if (IdValue.Length != 10 || !IdValue.All(char.IsDigit))
            {
                await DisplayAlert("Sign up", $"{IdValue} is not a valid number", "Ok");
                return;
            }
            signup.Phone = IdValue;
            signup.Password = passwordValue;
            signup.CheckBox = checkbox;
        }
        //API Integration will be done here !!




        await DisplayAlert("Sign up", $"Email: {signup.Email}\nPhone: {signup.Phone}\nPassword: {signup.Password}\nCheckBox: {signup.CheckBox}","Ok");
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
}