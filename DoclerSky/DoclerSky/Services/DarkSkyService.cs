using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
using System.Net.Http;
using DoclerSky.Models;

namespace DoclerSky.Services
{
    public class DarkSkyService : IDarkSkyService
    {
        #region Private Members

        /// <summary>
        /// Secret key is required parameter for API call
        /// </summary>
        private readonly string ApiKey;

        /// <summary>
        /// By giving a list of insignificant parameters to our API call, we can remove them from the response
        /// </summary>
        private readonly string ExcludedParams;

        /// <summary>
        /// HttpClient for our API call
        /// </summary>
        private readonly HttpClient client;

        #endregion

        #region Constructor

        /// <summary>
        /// Sets the client, ApiKey, and ExcludedParams
        /// </summary>
        public DarkSkyService()
        {
            client = new HttpClient
            {
                BaseAddress = new Uri(ConfigurationManager.AppSettings["BaseAddress"])
            };

            ApiKey = ConfigurationManager.AppSettings["SecretKey"];
            ExcludedParams = ConfigurationManager.AppSettings["ExcludedParams"];
        }

        #endregion

        #region API call

        /// <summary>
        /// Calls the DarkSky API with the requested parameters
        /// </summary>
        /// <param name="coordinates"></param>
        /// <returns>Forecast response List</returns>
        public async Task<List<ForecastResponse>> GetForecastResponsesAsync(string coordinates)
        {
            var result = new List<ForecastResponse>();

            // The request url with properties
            var request = ApiKey + "/" + coordinates + "?exclude=" + ExcludedParams;

            // The actual API call
            var response = await client.GetAsync(request);

            // StatusCode check
            if (response.StatusCode != System.Net.HttpStatusCode.OK)
            {
                throw new Exception("The status code is : " + response.StatusCode);
            }

            // Deserializing
            dynamic deserializedResponse = Newtonsoft.Json.JsonConvert.DeserializeObject(await response.Content.ReadAsStringAsync());

            // using temporal variable for easyer mapping
            var currentWeather = deserializedResponse.currently;

            // The first element of FirecastResponse is our CurrentWeather
            result.Add(new ForecastResponse
            {
                ApparentTemperature = currentWeather.apparentTemperature,
                Humidity = currentWeather.humidity,
                Temperature = currentWeather.temperature,
                UVIndex = currentWeather.uvIndex,
                WindSpeed = currentWeather.windSpeed,
                DateTime = DateTimeOffset.FromUnixTimeSeconds((long)currentWeather.time),
                Icon = currentWeather.icon
            });

            // using temporal variable for easyer mapping
            var forecast = deserializedResponse.daily.data;

            // We want to skip the first 2 iteration of the foreach, because it gives us irrelevant weather data
            int index = 0;

            foreach (var item in forecast)
            {
                if (index > 1)
                {
                    // The second and other elements of the ForecastResponse are the Forecast data
                    result.Add(new ForecastResponse
                    {
                        ApparentTemperature = item.apparentTemperatureHigh,
                        Humidity = item.humidity,
                        Temperature = item.temperatureHigh,
                        UVIndex = item.uvIndex,
                        WindSpeed = item.windSpeed,
                        DateTime = DateTimeOffset.FromUnixTimeSeconds((long)item.time),
                        Icon = item.icon
                    });
                }
                index++;
            }

            return result;
        }
        
        #endregion

    }
}
