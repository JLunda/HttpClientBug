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
        public IHttpClientFactory HttpClientFactory { get; set; }

        public HttpClientUsingService(IHttpClientFactory httpClientFactory)
        {
            HttpClientFactory = httpClientFactory;
        }

        public async Task<IEnumerable<WeatherForecast>> GetWeather()
        {
            try
            {
                var httpClient = HttpClientFactory.CreateClient();

                Uri uri = new Uri($"{ApiConstants.Host}/{ApiConstants.ApiBase}");

                HttpResponseMessage result = await httpClient.GetAsync(uri);

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
