using DoclerSky.Services;
using DoclerSky.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using Unity;

namespace DoclerSky
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private IDarkSkyService _darkSkyService = new DarkSkyService();

        public MainWindow()
        {
            InitializeComponent();

            // Binding the DataContext to the needed Viewmodel 
            // TODO: create VM locator
            DataContext = new ForecastViewModel(_darkSkyService);

        }
    }
}
