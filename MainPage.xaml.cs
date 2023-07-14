using WeatherTracker.Models;
using WeatherTracker.Services;

namespace WeatherTracker;

public partial class MainPage : ContentPage
{
	public List<Forecastday> DaysList;
	private double longitude;
    private double latitude;

    public MainPage()
	{
		InitializeComponent();
		DaysList = new List<Forecastday>();
	}

	protected async override void OnAppearing()
	{
		base.OnAppearing();
		await GetLocation();
        var locResponse = await DisplayPromptAsync(title: "Provide location", message: "Please enter the location below", placeholder: "Enter Location City", accept: "Search", cancel: "Cancel");

        if (locResponse != null)
        {
            await GetWeatherDataCity(locResponse);
            infor(locResponse);
        }
        await GetWeatherData(latitude, longitude);
    }

	public async  Task GetLocation()
	{
		var location = await Geolocation.GetLocationAsync();
		latitude = location.Latitude;
		longitude = location.Longitude;
	}

	private async void TapMyLocation_Tapped(object sender, EventArgs e)
	{
        await GetLocation();
        await GetWeatherData(latitude,longitude);
    }

    public async Task GetWeatherData(double lat, double lon)
	{
        //remember to retrieve data by long and lati
        
        //var result = await ApiService.GetWeatherCity("Soshanguve");
    }

    private async void ImageButton_Clicked(object sender, EventArgs e)
    {
        var locResponse = await DisplayPromptAsync(title:"Provide location", message:"Please enter the location below", placeholder:"Enter Location City",accept:"Search", cancel:"Cancel");

        if (locResponse != null)
        {
            await GetWeatherDataCity(locResponse);
            infor(locResponse);
        }
    }

    public async Task GetWeatherDataCity(string city)
    {
        var result = await ApiService.GetWeatherCity(city);
        infor(result);
    }

    public void infor(dynamic result)
    {
        foreach (var item in result.forecast.forecastday)
        {
            DaysList.Add(item);
        }
        cvWeatherDays.ItemsSource = DaysList;

        lblCity.Text = result.location.name;

        //Custom increasing size of the images in url as WeatherAPI only shows 64x64 and it is not appealing in the application
        string url = result.current.condition.customIcon;
        string imgIconUrl = url.Replace("64x64", "128x128");
        imgWeatherIcon.Source = imgIconUrl;

        lblWeatherDeg.Text = result.current.temp_c.ToString("F0") + "°c";
        lblWeatherDescr.Text = result.current.condition.text;
        lblMaxTemp.Text = result.forecast.forecastday[0].day.maxtemp_c.ToString("F0") + "°";
        lblMinTemp.Text = result.forecast.forecastday[0].day.mintemp_c.ToString("F0") + "°";
    }

    private async void TapGestureRecognizer_Tapped(object sender, EventArgs e)
    {
        if (sender is Grid tappedGrid)
        {
            await Shell.Current.GoToAsync($"{nameof(DetailsPage)}?Clicked={tappedGrid}", new Dictionary<string, object> {  });
        }
        
    }
}

