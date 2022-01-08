using HttpClientBug.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace HttpClientBug.Interfaces
{
    public interface IHttpClientUsingService
    {
        Task<IEnumerable<WeatherForecast>> GetWeather();
    }
}
