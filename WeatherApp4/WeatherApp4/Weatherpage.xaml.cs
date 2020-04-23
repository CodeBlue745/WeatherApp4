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
        public Weatherpage()
        {
            InitializeComponent();
            LblTemp.Text = WeatherVals.CurTemp;
            LblSpeed.Text = WeatherVals.WindSpeed;
            LblDir.Text = WeatherVals.Degrees;
            LblPressure.Text = WeatherVals.Pressure;
            LblHumidity.Text = WeatherVals.Humidity;
            LblSunrise.Text = WeatherVals.Sunrise;
            LblSunset.Text = WeatherVals.Sunset;
        }
    }
}