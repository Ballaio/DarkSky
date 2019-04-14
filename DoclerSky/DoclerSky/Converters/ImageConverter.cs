using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Data;
using System.Windows.Media.Imaging;

namespace DoclerSky.Converters
{
    public class ImageConverter : IMultiValueConverter
    {
        public object Convert(object[] values, Type targetType, object parameter, CultureInfo culture)
        {
            if (values[0] == DependencyProperty.UnsetValue)
            {
                return Binding.DoNothing;
            }

            BitmapImage image = new BitmapImage();
            var weatherType = (string)values[0];
            var folderPath = "pack://application:,,,/DoclerSky;component/Images/";
            string imgPath;

            switch (weatherType)
            {
                case "clear-day":
                    imgPath = "clear.png";
                    break;
                case "clear-night":
                    imgPath = "clear.png";
                    break;
                case "rain":
                    imgPath = "rain.jpg";
                    break;
                case "snow":
                    imgPath = "rain.jpg";
                    break;
                case "sleet":
                    imgPath = "sleet";
                    break;
                case "wind":
                    imgPath = "cloud.jpg";
                    break;
                case "fog":
                    imgPath = "cloud.jpg";
                    break;
                case "cloudy":
                    imgPath = "cloud.jpg";
                    break;
                case "partly-cloudy-day":
                    imgPath = "cloud.jpg";
                    break;
                case "partly-cloudy-night":
                    imgPath = "cloud.jpg";
                    break;
                default: return Binding.DoNothing;
            }


            image.BeginInit();
            image.UriSource = new Uri(folderPath + imgPath);
            image.EndInit();

            return image;
        }

        public object[] ConvertBack(object value, Type[] targetTypes, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
