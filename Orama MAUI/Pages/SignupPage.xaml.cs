
using Orama_MAUI.Model;

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
        Navigation.PushAsync(new LoginPage());
    }

    private void SendButton_Clicked(object sender, EventArgs e)
    {
        DisplayAlert("Sing Up", "will config later", "OK");
    }

    private void SignupButton_Clicked(object sender, EventArgs e)
    {
        var signup = new Signup();

        string emailValue = EmailEntry.Text?.Trim();
        string passwordValue = PasswordEntry1.Text?.Trim();
        string confirmPasswordValue = PasswordEntry2.Text?.Trim();
        string codeValue = CodeEntry.Text?.Trim();
        bool checkbox = Checkbox.IsChecked;

        if (string.IsNullOrEmpty(emailValue))
        {
            DisplayAlert("Sign up", "Email/Phone is a required field", "OK");
            return;
        }
        if (string.IsNullOrEmpty(passwordValue))
        {
            DisplayAlert("Sign up", "Password is a required field", "OK");
            return;
        }
        if (string.IsNullOrEmpty(confirmPasswordValue))
        {
            DisplayAlert("Sign up", "Confirm Password is a required field", "OK");
            return;
        }
        if (!passwordValue.Equals(confirmPasswordValue))
        {
            DisplayAlert("Sign up", "Password and Confirm Password has to match", "OK");
            return;
        }
        if (string.IsNullOrEmpty(codeValue))
        {
            DisplayAlert("Sign up", "Enter Code for Credential verification", "OK");
            return;
        }
        if (!checkbox)
        {
            DisplayAlert("Sign up", "Checkbox required!", "OK");
            return;
        }

        //if user enter a string without @ it consider it as phone number value!! fix it 
        if (emailValue.Contains("@"))
        {
            signup.Email = emailValue;
            signup.Password = passwordValue;
            signup.Code = codeValue;
            signup.CheckBox = checkbox;
        }
        else
        {
            signup.Phone = emailValue;
            signup.Password = passwordValue;
            signup.Code = codeValue;
            signup.CheckBox = checkbox;
        }
        string message = $"Email: {signup.Email}\nPhone: {signup.Phone}\nPassword: {signup.Password}\nCode: {signup.Code}\nCheckbox: {signup.CheckBox}";
        DisplayAlert("Login", message, "Ok");
    }
}