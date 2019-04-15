using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace DoclerSky.ViewModels.Base
{
    /// <summary>
    /// All other Viewmodels will inherit from BaseViewModel
    /// </summary>
    public class BaseViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        /// <summary>
        /// Updates all binding element on Property change
        /// </summary>
        /// <param name="name"></param>
        public void OnPropertyChanged([CallerMemberName()]string name = null)
        {
            PropertyChanged(this, new PropertyChangedEventArgs(name));
        }
    }
}
