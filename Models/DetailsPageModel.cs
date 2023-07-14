using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;

namespace WeatherTracker.Models
{
    [QueryProperty("Text", "Clicked")]
    public partial class DetailsPageModel:ObservableObject
    {
        [ObservableProperty]
        string text;

        /*[RelayCommand]
        async Task GoBack()
        {
            await Shell.Current.GoToAsync("..");
        }*/
    }
}
