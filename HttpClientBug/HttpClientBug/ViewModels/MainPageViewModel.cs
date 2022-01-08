using HttpClientBug.Interfaces;
using HttpClientBug.Models;
using HttpClientBug.Services;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Text;
using Xamarin.Forms;

namespace HttpClientBug.ViewModels
{
    public class MainPageViewModel : INotifyPropertyChanged
    {
        public IHttpClientUsingService HttpClientUsingService { get; set; }
        public Command GetWeatherCommand { get; }
        public ObservableCollection<WeatherForecast> WeatherForecasts { get; set; }
        public event PropertyChangedEventHandler PropertyChanged;

        public MainPageViewModel() : this(App.ServiceProvider.GetRequiredService<IHttpClientUsingService>())
        {
            GetWeatherCommand = new Command(GetWeather);

            WeatherForecasts = new ObservableCollection<WeatherForecast>();

            GetWeather();
        }

        public MainPageViewModel(IHttpClientUsingService httpClientUsingService)
        {
            HttpClientUsingService = httpClientUsingService;
        }

        private async void GetWeather()
        {
            try
            {
                var forecasts = await HttpClientUsingService.GetWeather();

                foreach (var forecast in forecasts)
                {
                    WeatherForecasts.Add(forecast);
                }
            }
            catch (Exception ex)
            {
                //TODO: Log to logging service.
            }
        }
    }
}
