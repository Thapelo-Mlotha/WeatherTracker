using WeatherTracker.Models;
using WeatherTracker.Services;

namespace WeatherTracker;

public partial class DetailsPage : ContentPage
{
    public DetailsPage(DetailsPageModel model)
    {
        InitializeComponent();
        BindingContext = model;

        var result = ApiService.GetWeatherCity("Soshanguve");

        //populate detailsPage
        
    }

    private async void Button_Clicked(object sender, EventArgs e)
	{
        await Shell.Current.GoToAsync("..");
    }
}