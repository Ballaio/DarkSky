using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoclerSky.Helpers
{
    public class GetImagePath
    {
        public static string Convert(string icon)
        {

            string imgPath;

            switch (icon)
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
                default:
                    imgPath = "";
                    break;
            }

            return "/Images/" + imgPath;
        }
    }
}
