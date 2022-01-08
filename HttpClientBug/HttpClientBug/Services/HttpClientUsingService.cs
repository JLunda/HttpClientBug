using HttpClientBug.Constants;
using HttpClientBug.Interfaces;
using HttpClientBug.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace HttpClientBug.Services
{
    internal class HttpClientUsingService : IHttpClientUsingService
    {
        HttpClient Client { get; set; }

        public HttpClientUsingService()
        {
            Client = new HttpClient();
        }

        public async Task<IEnumerable<WeatherForecast>> GetWeather()
        {
            try
            {
                Uri uri = new Uri($"{ApiConstants.Host}/{ApiConstants.ApiBase}");

                HttpResponseMessage result = await Client.GetAsync(uri);

                if (result.IsSuccessStatusCode)
                {
                    return JsonConvert.DeserializeObject<List<WeatherForecast>>(await result.Content.ReadAsStringAsync());
                }
            }
            catch (Exception ex)
            {
                //TODO: Log to logging service.
            }

            return null;
        }
    }
}
