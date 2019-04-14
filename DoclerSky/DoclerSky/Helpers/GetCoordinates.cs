using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoclerSky.Helpers
{
    public class GetCoordinates
    {
        public static string GetCoordinatesFromConfig(string cityName)
        {
            switch (cityName)
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

    }
}
