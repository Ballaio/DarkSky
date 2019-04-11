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
        /// <param name="coordinates"></param>
        /// <returns>Forecast response List</returns>
        Task<List<ForecastResponse>> GetForecastResponsesAsync(string coordinates);
    }
}
