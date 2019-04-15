using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoclerSky.Models
{
    #region Model structure

    /// <summary>
    /// Model for the API response
    /// </summary>
    public class ForecastResponse
    {
        public double Temperature { get; set; }
        public double ApparentTemperature { get; set; }
        public double WindSpeed { get; set; }
        public double Humidity { get; set; }
        public int UVIndex { get; set; }
        public DateTimeOffset DateTime { get; set; }
        public string Icon { get; set; }
    }
    #endregion
}
