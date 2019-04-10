using DoclerSky.Services;
using DoclerSky.ViewModels.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

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
            set
            {
                _selectedCity = value as TabItem;
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
