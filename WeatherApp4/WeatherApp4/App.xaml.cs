using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using WeatherApp4.Services;
using WeatherApp4.Views;

namespace WeatherApp4
{
    public partial class App : Application
    {

        public App()
        {
            InitializeComponent();

            DependencyService.Register<MockDataStore>();
            MainPage = new MainPage();
        }

        protected override void OnStart()
        {
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}
