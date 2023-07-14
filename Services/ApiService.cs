using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using WeatherTracker.Models;

namespace WeatherTracker.Services
{
    public static class ApiService
    {
        
        public static async Task<Root> GetWeatherCity(string city)
        {
            var httpClient = new HttpClient();
            var response = await httpClient.GetStringAsync(string.Format("https://api.weatherapi.com/v1/forecast.json?key=bcc91e83e90f47c5af8223953231007&q={0}&days=5&aqi=no&alerts=no", city));
            return JsonConvert.DeserializeObject<Root>(response);
        }

    }
}
