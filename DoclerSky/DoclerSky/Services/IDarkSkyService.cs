using DoclerSky.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoclerSky.Services
{
    public interface IDarkSkyService
    {
        /// <summary>
        /// Task for DarkSky API call
        /// </summary>
        /// <param name="latitude"></param>
        /// <param name="longitude"></param>
        /// <param name="lang"></param>
        /// <returns>Forecast response List</returns>
        Task<List<ForecastResponse>> GetForecastResponsesAsync(string latitude, string longitude, string lang);
    }
}
