using CommunityToolkit.Mvvm.ComponentModel;
using System.Collections.ObjectModel;
using Orama_MAUI.Models;
using CommunityToolkit.Mvvm.Input;


namespace Orama_MAUI.ViewModels;

partial class FeedbackViewModel: ObservableObject
{
    [ObservableProperty]
    private ObservableCollection<Feedback> list = new();

    [ObservableProperty]
    private Feedback feedback = new();

    [RelayCommand]
    public async Task AddAsync()
    {
        if (string.IsNullOrWhiteSpace(Feedback.Type) || string.IsNullOrWhiteSpace(Feedback.Message))
        {
            await Application.Current.MainPage.DisplayAlert("Validation Error", "Please enter both Title and Description.", "OK");
            return;
        }
        List.Add(Feedback);
        Feedback = new();
    }
}
