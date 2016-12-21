using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Media.Imaging;
using Windows.UI.Xaml.Navigation;
using Windows.Devices.Geolocation;
using Windows.UI.Notifications;
using static WeatherApp.WeatherForecast;


// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace WeatherApp
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        public MainPage()
        {
            this.InitializeComponent();
        }



        private async void Page_Loaded(object sender, RoutedEventArgs e)
        {
            var position = await LocationManager.GetPosition();
            RootObject MyWeather = await OpenWeatherProxy.GetWeather(position.Coordinate.Latitude, position.Coordinate.Longitude);

            string icon = String.Format("ms-appx:///Assets/Weather/{0}.png", MyWeather.weather[0].icon);
            ResultImage.Source = new BitmapImage(new Uri(icon, UriKind.Absolute));
            NameTb.Text = MyWeather.name;
            TempTb.Text = "Temp: " + MyWeather.main.temp;
            DescTb.Text = MyWeather.weather[0].description;
            var din = MyWeather.dt;

            System.DateTime Date = new DateTime(1970, 1, 1, 0, 0, 0, 0, System.DateTimeKind.Utc);
            Date = Date.AddSeconds(din);
            dayTb.Text = "Date: " + Date.ToString("dd-MM-yyyy");           
        }

        private async void Celsius_Click(object sender, RoutedEventArgs e)
        {
            var position = await LocationManager.GetPosition();
            RootObject MyWeather = await OpenWeatherProxy.GetWeather(position.Coordinate.Latitude, position.Coordinate.Longitude);

            string icon = String.Format("ms-appx:///Assets/Weather/{0}.png", MyWeather.weather[0].icon);
            ResultImage.Source = new BitmapImage(new Uri(icon, UriKind.Absolute));
            NameTb.Text = MyWeather.name;
            TempTb.Text = "Temp: " + MyWeather.main.temp;
            DescTb.Text = MyWeather.weather[0].description;
            var din = MyWeather.dt;

            System.DateTime Date = new DateTime(1970, 1, 1, 0, 0, 0, 0, System.DateTimeKind.Utc);
            Date = Date.AddSeconds(din);
            dayTb.Text = "Date: " + Date.ToString("dd-MM-yyyy");
        }

        private async void Fahrenheit_Click(object sender, RoutedEventArgs e)
        {
            var position = await LocationManager.GetPosition();
            RootObject MyWeather = await OpenWeatherProxy.Weather2F(position.Coordinate.Latitude, position.Coordinate.Longitude);

            string icon = String.Format("ms-appx:///Assets/Weather/{0}.png", MyWeather.weather[0].icon);
            ResultImage.Source = new BitmapImage(new Uri(icon, UriKind.Absolute));
            NameTb.Text = MyWeather.name;
            TempTb.Text = "Temp: " + MyWeather.main.temp;
            DescTb.Text = MyWeather.weather[0].description;

            var din = MyWeather.dt;
            System.DateTime Date = new DateTime(1970, 1, 1, 0, 0, 0, 0, System.DateTimeKind.Utc);
            Date = Date.AddSeconds(din);
            dayTb.Text = "Date: " + Date.ToString("dd-MM-yyyy");
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Forecast_Click(object sender, RoutedEventArgs e)
        {
            Frame.Navigate(typeof(Forecast));


        }




        private void Navigate_Click(object sender, RoutedEventArgs e)
        {
            Frame.Navigate(typeof(Forecast));

        }
    }
}
