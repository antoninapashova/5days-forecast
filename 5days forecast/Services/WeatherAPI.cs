using Newtonsoft.Json;
using System;
using System.Diagnostics;
using System.Net.Http;
using System.Threading.Tasks;
using UnweWeatherApp2.Models;

namespace UnweWeatherApp2.Services
{
    class WeatherAPI
    {
         
        public HttpClient _client;
        public WeatherAPI()
        {
            _client = new HttpClient();
        }
        public async Task<Root> Get5dayforecast(string query)
        {
            Root weatherdata = null;
            try
            {
                var response = await _client.GetAsync(query);
                if (response.IsSuccessStatusCode)
                {
                    var content = await response.Content.ReadAsStringAsync();
                    weatherdata = JsonConvert.DeserializeObject<Root>(content);
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine("\t\tERROR {0}", ex.Message);
            }
            return weatherdata;
        }
    }
}

