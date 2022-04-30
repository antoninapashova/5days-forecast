using FiveDayForecast;
using System;
using System.Collections.ObjectModel;
using UnweWeatherApp2;
using UnweWeatherApp2.Models;
using UnweWeatherApp2.Services;
using Xamarin.Forms;

namespace _5days_forecast
{
    public partial class MainPage : ContentPage
    {
        WeatherAPI weatherApi;
        Sys sys;
        LongToDateTimeConverter converter;
         ObservableCollection<WeatherData> weather = new ObservableCollection<WeatherData>();
        public ObservableCollection<WeatherData> Weather { get { return weather; } }


        public MainPage()
        {
            InitializeComponent();
           
            weatherApi = new WeatherAPI();
            sys = new Sys();
            converter = new LongToDateTimeConverter();
        }

        string GenerateRequestUri(string endpoint)
        {
            string requestUri = endpoint;
            requestUri += $"?q={_cityEntry.Text}";
            requestUri += $"&APPID={Constants.OpenWeatherMapAPIKey}";
            return requestUri;
        }

        async void OnGetWeatherButtonClicked(object sender, EventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(_cityEntry.Text))
            {
                var weatherData = await weatherApi.Get5dayforecast(GenerateRequestUri(Constants.OpenWeatherMapEndpoint));
                weatherData.list.ForEach(x => weather.Add(x));

                ListView listview = new ListView();
                listview.ItemsSource = weather;

                BindingContext = listview;
                
            }
        }

    }
}
