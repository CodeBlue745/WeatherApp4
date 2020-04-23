using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
//----------------------------------------------------
//These are the new libraries we will use in this application the most.
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using System.Net;
using Newtonsoft.Json.Linq;
namespace WeatherApp4
{
    /// <summary>
    /// Name the Landing Page and inherit all the attributes from ContentPage.
    /// </summary>
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class LandingPage : ContentPage
    {
        /// <summary>
        /// Start this application.
        /// </summary>
        public LandingPage()
        {
            InitializeComponent();
        }
        /// <summary>
        /// This click event tells the user the weather or their zipcode.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="args"></param>
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
                        string json = wc.DownloadString($"http://api.openweathermap.org/data/2.5/weather?zip={Entry1.Text}&appid={APIKey}&units=imperial");
                        //I had to parse json first before jo2 so that I could get the city name out of it.
                        JObject jo = JObject.Parse(json);
                        //This one Parses jo by finding the string "main, turning it into a string, and parsing it again into an object called main."
                        JObject coord = JObject.Parse(jo["coord"].ToString());
                        //this string is equal to the longitude.
                        string Lon = coord["lon"].ToString();
                        string Lat = coord["lat"].ToString();
                        string APIKey2 = "22a94ad955dbedfff080868ed126662e";
                        string json2 = wc.DownloadString($"https://api.sunrise-sunset.org/json?lat={Lat}&lng={Lon}&appid={APIKey2}&units=imperial");
                        //Here we create JSON objects. the first parses the information we gather from the API and puts it in jo2.
                        //The first is the main object.
                        JObject main = JObject.Parse(jo["main"].ToString());
                        //Parse each item in "wind" to a string and put it in JoWindSpeed to be called later.
                        JObject JoWindSpeed = JObject.Parse(jo["wind"].ToString());
                        //I tried to get the cloud images working, but don't know enough to do that yet.
                        //JObject JoWindSpeed = JObject.Parse(jo["wind"].ToString());
                        //Parse sys string
                        JObject jo2 = JObject.Parse(json2);
                        JObject LongandLat = JObject.Parse(jo2["results"].ToString());
                        //Assign each JSON object to a unique WeatherVals value. Each JSON object is a list of elements that has been parsed.
                        //these get data from the json string.
                        WeatherVals.CityName = jo["name"].ToString();
                        WeatherVals.CityName = jo["name"].ToString();
                        WeatherVals.CurTemp = main["temp"].ToString();
                        WeatherVals.LowTemp = main["temp_min"].ToString();
                        WeatherVals.HighTemp = main["temp_max"].ToString();
                        WeatherVals.Pressure = main["pressure"].ToString();
                        WeatherVals.Humidity = main["humidity"].ToString();
                        WeatherVals.WindSpeed = JoWindSpeed["speed"].ToString();
                        WeatherVals.Degrees = JoWindSpeed["deg"].ToString();
                        //these two get data from the json2 downloaded string.
                        WeatherVals.Sunrise = LongandLat["sunrise"].ToString();
                        WeatherVals.Sunset = LongandLat["sunset"].ToString();
                        //Add Weather page.
                        Navigation.PushAsync(new Weatherpage());
                    }
                    //catch exceptions and tell user to close this window.
                    catch (Exception ex) { DisplayAlert("Error", ex.Message, "Close"); }
                }
            }
            else
            {//tell user the error and to close this dialog window.
                DisplayAlert("Invalid Input", "Please type in a zip code", "Close");
            }
        }
    }
}