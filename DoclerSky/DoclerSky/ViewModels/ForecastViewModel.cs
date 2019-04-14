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

        private MemoryCache cachedData;

        private string selectedCity;

        private IDarkSkyService _darkSkyService;

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
                Task.Run(() => GetForecast().Wait());
            }
        }

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
        /// Initializes our darkSkyService
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
