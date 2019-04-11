using DoclerSky.Commands;
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

namespace DoclerSky.ViewModels
{
    public class ForecastViewModel : BaseViewModel
    {

        #region Private Members

        /// <summary>
        /// Property to call the DarkSky API
        /// </summary>
        private IDarkSkyService _darkSkyService;

        /// <summary>
        /// The selected Tabitem (we will use it in the API call)
        /// </summary>
        private ICommand _cityData;

        private TabItem _selectedCity;

        #endregion

        #region Public Members

        /// <summary>
        /// Binds to the TabControl, gets the selected Tabitem
        /// </summary>
        public TabItem SelectedCity
        {
            get
            {
                return _selectedCity;
            }
            set => _selectedCity = (TabItem)value;
        }

        public ICommand SetCityData
        {
            get
            {
                return _cityData = new RelayCommandAsync(GetForecast, (x) => true);
            }
        }

        public async Task GetForecast()
        {
            var response = await _darkSkyService.GetForecastResponsesAsync(GetCoordinates());
        }

        public string GetCoordinates()
        {
            switch (_selectedCity.Name)
            {
                case "Budapest":
                    return ConfigurationManager.AppSettings["Budapest"];
                case "Luxembourg":
                    return ConfigurationManager.AppSettings["Luxembourg"];
                case "Debrecen":
                    return ConfigurationManager.AppSettings["Debrecen"];
                case "Pecs":
                    return ConfigurationManager.AppSettings["Pecs"];
                case "Wienna":
                    return ConfigurationManager.AppSettings["Wienna"];
                case "Prague":
                    return ConfigurationManager.AppSettings["Prague"];
                case "München":
                    return ConfigurationManager.AppSettings["München"];
                case "Amsterdam":
                    return ConfigurationManager.AppSettings["Amsterdam"];
                default:
                    return null;
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
        }

        #endregion
    }
}
