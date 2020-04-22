using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
//----------------------------------------------------
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using System.Net;
using Newtonsoft.Json.Linq;
namespace WeatherApp4
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class LandingPage : ContentPage
    {
        public LandingPage()
        {
            InitializeComponent();
        }
        private void OnButtonClicked(object sender, EventArgs args)
        {
            if (Entry1.Text != "")
            {
                //Start a new Webclient.
                using (WebClient wc = new WebClient())
                {
                    try
                    {
                        //Set Headers for the output code.
                        wc.Headers[HttpRequestHeader.ContentType] = "application/x-www-form-urlencoded";
                        //The API Key for my online account of weather information is located at the following URL where we will download the data from.
                        string APIKey = "ffbbc988898533289b11a4b365beb2b3";
                        string json = wc.DownloadString($"https://api.openweathermap.org/data/2.5/weather?q=Orem,USA&appid=ffbbc988898533289b11a4b365beb2b3");
                        //Here we create two JSON objects.
                        JObject jo = JObject.Parse(json);


                        JObject main = JObject.Parse(jo["main"].ToString());


                        //Assign each JSON object to a unique WeatherVals value.
                        WeatherVals.CurTemp = main["temp"].ToString();
                        WeatherVals.LowTemp = main["temp_min"].ToString();
                        WeatherVals.HighTemp = main["temp_max"].ToString();
                        WeatherVals.CityName = jo["name"].ToString();
                        Navigation.PushAsync(new Weatherpage());
                    }
                    catch (Exception ex) { DisplayAlert("Error", ex.Message, "Close"); }
                }
            }
            else
            {
                DisplayAlert("Invalid Input", "Please type in a zip code", "Close");
            }
        }
    }
}