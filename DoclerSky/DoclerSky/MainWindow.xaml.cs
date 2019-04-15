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
        private ResourceDictionary templatePath = new ResourceDictionary
        {
            Source = new Uri("/Templates/TabItem.xaml", UriKind.Relative)
        };

        public MainWindow()
        {
            InitializeComponent();

            // Binding the DataContext to the needed Viewmodel 
            // TODO: create VM locator
            DataContext = new ForecastViewModel(_darkSkyService);

        }

        private void Hu_localization_Selected(object sender, RoutedEventArgs e)
        {
            ResourceDictionary resourceChange = new ResourceDictionary
            {
                Source = new Uri("/Localization/StringResources.hu.xaml", UriKind.Relative)
            };
            Resources.MergedDictionaries.Clear();
            Resources.MergedDictionaries.Add(templatePath);
            Resources.MergedDictionaries.Add(resourceChange);

        }

        private void Eng_localization_Selected(object sender, RoutedEventArgs e)
        {
            ResourceDictionary resourceChange = new ResourceDictionary
            {
                Source = new Uri("/Localization/StringResources.eng.xaml", UriKind.Relative)
            };
            Resources.MergedDictionaries.Clear();
            Resources.MergedDictionaries.Add(templatePath);
            Resources.MergedDictionaries.Add(resourceChange);

        }
    }
}
