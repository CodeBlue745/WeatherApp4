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
            //LblSpeed.Text = WeatherVals.;
            //LblDir.Text = WeatherVals.CurTemp;
            //LblPressure.Text = WeatherVals.CurTemp;
            //LblHumidity.Text = WeatherVals.CurTemp;
            //LblSunrise.Text = WeatherVals.CurTemp;
            //LblSunset.Text = WeatherVals.CurTemp;
        }
    }
}