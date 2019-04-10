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

        /// <summary>
        /// Calls the DarkSky API with the requested parameters
        /// </summary>
        /// <param name="latitude"></param>
        /// <param name="longitude"></param>
        /// <param name="lang"></param>
        /// <returns>Forecast response List</returns>
        public async Task<List<ForecastResponse>> GetForecastResponsesAsync(string latitude, string longitude, string lang)
        {
            // The request url with properties
            var request = latitude + "," + longitude + "?exclude=" + ExcludedParams + "&lang=" + lang;

            // The actual API call
            var response = await client.GetAsync(request);

            // StatusCode check
            if (response.StatusCode != System.Net.HttpStatusCode.OK)
            {
                throw new Exception("The status code is : " + response.StatusCode);
            }

            // TODO: map response to "ForecastResponse"
            throw new NotImplementedException();
        }

        #endregion
    }
}
