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
        private async void Forecast_Click(object sender, RoutedEventArgs e)
        {

            #region -Fetch weather data from API-
            var position = await LocationManager.GetPosition();
            RootObjectF Forecast = await WeatherForecast.Forecast(position.Coordinate.Latitude, position.Coordinate.Longitude, 16);
            #endregion
            #region -Creating and binding into weather list-
            List<DayWeather> WeatherList = new List<DayWeather>();
            foreach (var tempDayWeather in Forecast.list)
            {
                DayWeather Dw = new DayWeather();
                Dw.Icon= String.Format("ms-appx:///Assets/Weather/{0}.png", Forecast.list[1].weather[0].icon);
                Dw.Description = tempDayWeather.weather[0].description;
                Dw.Temp= tempDayWeather.temp.day.ToString();
                System.DateTime tDate = new DateTime(1970, 1, 1, 0, 0, 0, 0, System.DateTimeKind.Utc);
                Dw.WeatherDate=tDate.AddSeconds(tempDayWeather.dt).ToString("dd-MM-yyyy");
                WeatherList.Add(Dw);
            }
            #endregion
            string icon = String.Format("ms-appx:///Assets/Weather/{0}.png", Forecast.list[1].weather[0].icon);
            ResultImage2.Source = new BitmapImage(new Uri(icon, UriKind.Absolute));

            var date1 = Forecast.list[1].dt;
            System.DateTime Date = new DateTime(1970, 1, 1, 0, 0, 0, 0, System.DateTimeKind.Utc);
            Date = Date.AddSeconds(date1);
            DateTB.Text = "Date: " + Date.ToString("dd-MM-yyyy");
            DescriptionB.Text = "Description: " + Forecast.list[1].weather[0].description;
            TempFBlock.Text = "Temp: " + Forecast.list[1].temp.day.ToString();

            //2

            string icon2 = String.Format("ms-appx:///Assets/Weather/{0}.png", Forecast.list[2].weather[0].icon);
            ResultImage3.Source = new BitmapImage(new Uri(icon2, UriKind.Absolute));

            var date2 = Forecast.list[2].dt;
            System.DateTime Date2 = new DateTime(1970, 1, 1, 0, 0, 0, 0, System.DateTimeKind.Utc);
            Date2 = Date2.AddSeconds(date2);
            DateTB3.Text = "Date: " + Date2.ToString("dd-MM-yyyy");
            DescriptionB3.Text = "Description: " + Forecast.list[2].weather[0].description;
            TempFBlock3.Text = "Temp: " + Forecast.list[2].temp.day.ToString();

            //3

            string icon3 = String.Format("ms-appx:///Assets/Weather/{0}.png", Forecast.list[3].weather[0].icon);
            ResultImage4.Source = new BitmapImage(new Uri(icon3, UriKind.Absolute));

            var date3 = Forecast.list[1].dt;
            System.DateTime Date3 = new DateTime(1970, 1, 1, 0, 0, 0, 0, System.DateTimeKind.Utc);
            Date3 = Date.AddSeconds(date3);
            DateTB4.Text = "Date: " + Date3.ToString("dd-MM-yyyy");
            DescriptionB4.Text = "Description: " + Forecast.list[3].weather[0].description;
            TempFBlock4.Text = "Temp: " + Forecast.list[3].temp.day.ToString();
        }
     }
}
