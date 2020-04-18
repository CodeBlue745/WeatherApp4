using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
//----------------------------------------------------
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using System.Net;
//using Newtonsoft.Json.Linq;
namespace WeatherApp4
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class LandingPage : ContentPage
    {
        public LandingPage()
        {
            async void OnButtonClicked(object sender, EventArgs args)
            { 
                await Label.RelRotateTo(360, 1000)
            }
            //I put in the API Key
            string APIkey = "ffbbc988898533289b11a4b365beb2b3";
            //I added the JSON code to access a Web Client.
            using (WebClient wc = new WebClient())
                UserInput = ;
                EntryZipcode = UserInput().Tostring();
            {
                wc.Headers[HttpRequestHeader.ContentType] = "application/x-www-form-urlencoded";
                //The API Key for my online account of weather information is located at the following URL where we will download the data from.
                string json = wc.DownloadString($"http://api.openweathermap.org/data/2.5/weather?zip={EntryZipCode.Text}&appid={APIkey}&units=imperial");
            }
            InitializeComponent();
        }
    }
}