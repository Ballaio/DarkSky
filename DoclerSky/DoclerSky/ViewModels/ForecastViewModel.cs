using DoclerSky.Commands;
using DoclerSky.Helpers;
using DoclerSky.Models;
using DoclerSky.Services;
using DoclerSky.ViewModels.Base;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Input;
using System.Runtime.Caching;

namespace DoclerSky.ViewModels
{
    public class ForecastViewModel : BaseViewModel
    {

        #region Private Members

        // Property for cache usage 
        private MemoryCache cachedData;

        // Property for the currently selected Tabitem
        private string selectedCity;

        // DarkSkyService
        private IDarkSkyService _darkSkyService;

        // The main model for UI data binding
        private List<ForecastResponse> _forecast;

        #endregion

        #region Public Members

        /// <summary>
        /// Binds to the TabControl, gets the selected Tabitem
        /// </summary>
        public TabItem SelectCity
        {
            set
            {
                selectedCity = value.Name;

                // On selection change, it calls the GetForecast function to Refresh UI data
                Task.Run(() => GetForecast().Wait());
            }
        }

        /// <summary>
        /// The object which contains nearly all the UI data, gets refreshed from API call
        /// </summary>
        public List<ForecastResponse> Forecast
        {
            get
            {
                return _forecast;
            }
            set
            {
                _forecast = value;
                OnPropertyChanged();
            }
        }

        /// <summary>
        /// The async Task for API call, it also cashes the response data for the selected City
        /// </summary>
        /// <returns></returns>
        public async Task GetForecast()
        {
            if (!cachedData.Contains(selectedCity))
            {
                var expiration = DateTimeOffset.UtcNow.AddMinutes(5);
                var response = await _darkSkyService.GetForecastResponsesAsync(GetCoordinates.GetCoordinatesFromConfig(selectedCity));
                Forecast = response;

                cachedData.Add(selectedCity, Forecast, expiration);
            }
            else
            {
                Forecast = cachedData.GetCacheItem(selectedCity).Value as List<ForecastResponse>;
            }
        }

        #endregion

        #region Constructor

        /// <summary>
        /// Initializes our darkSkyService, and memory cache
        /// </summary>
        /// <param name="darkSkyService"></param>
        public ForecastViewModel(IDarkSkyService darkSkyService)
        {
            _darkSkyService = darkSkyService;
            cachedData = MemoryCache.Default;
        }

        #endregion
    }
}
