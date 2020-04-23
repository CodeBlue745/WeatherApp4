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
            //Make sure the input is not empty and it is a 5-digit Zip code, not a specifit Zip code
            if (Entry1.Text != "" && Entry1.Text.Length < 6)
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
                        string json = wc.DownloadString($"https://api.openweathermap.org/data/2.5/weather?q={Entry1.Text},USA&appid=ffbbc988898533289b11a4b365beb2b3&units=imperial");
                        //Here we create two JSON objects. the first parses the information we gather from the API and puts it in jo.
                        JObject jo = JObject.Parse(json);

                        //This one Parses jo by finding the string "main, turning it into a string, and parsing it again into an object called main."
                        JObject main = JObject.Parse(jo["main"].ToString());
                        JObject weather = JObject.Parse(jo["weather"].ToString());
                        JObject JoWindSpeed = JObject.Parse(jo["wind"].ToString());
                        JObject sys = JObject.Parse(jo["sys"].ToString());


                        //Assign each JSON object to a unique WeatherVals value.
                        WeatherVals.CityName = jo["name"].ToString();
                        WeatherVals.CurTemp = main["temp"].ToString();
                        WeatherVals.LowTemp = main["temp_min"].ToString();
                        WeatherVals.HighTemp = main["temp_max"].ToString();
                        WeatherVals.Pressure = main["pressure"].ToString();
                        WeatherVals.Humidity = main["humidity"].ToString();
                        WeatherVals.WindSpeed = JoWindSpeed["speed"].ToString();
                        WeatherVals.Degrees = JoWindSpeed["deg"].ToString();
                        WeatherVals.Sunrise = sys["sunrise"].ToString();
                        WeatherVals.Sunset = sys["sunset"].ToString();



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