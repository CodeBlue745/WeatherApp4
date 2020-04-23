using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace WeatherApp4
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Weatherpage : ContentPage
    {
        /// <summary>
        /// Assign each label to a value that can be changed at any time in WeatherVals. 
        /// </summary>
        public Weatherpage()
        {
            InitializeComponent();
            LblCityName.Text = WeatherVals.CityName;
            LblTemp.Text = WeatherVals.CurTemp;
            LblLow.Text = WeatherVals.LowTemp;
            LblHigh.Text = WeatherVals.HighTemp;
            LblSpeed.Text = WeatherVals.WindSpeed;
            LblDir.Text = WeatherVals.Degrees;
            LblPressure.Text = WeatherVals.Pressure;
            LblHumidity.Text = WeatherVals.Humidity;
            LblSunrise.Text = WeatherVals.Sunrise;
            LblSunset.Text = WeatherVals.Sunset;

        }
    }
}