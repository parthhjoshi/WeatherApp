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
using Windows.UI.Xaml.Navigation;
using static WeatherApp.WeatherForecast;

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=234238

namespace WeatherApp
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class Forecast : Page
    {
        public Forecast()
        {
            this.InitializeComponent();
        }

        private void Back_Click(object sender, RoutedEventArgs e)
        {
            Frame.GoBack();
        }
       

        private async void Page_Loaded(object sender, RoutedEventArgs e)
        {
            #region -Fetch weather data from API-
            var position = await LocationManager.GetPosition();
            RootObjectF Forecast = await WeatherForecast.Forecast(position.Coordinate.Latitude, position.Coordinate.Longitude, 5);
            #endregion
            #region -Creating and binding into weather list-
            List<DayWeather> WeatherList = new List<DayWeather>();
            foreach (var tempDayWeather in Forecast.list)
            {
                DayWeather Dw = new DayWeather();
                Dw.Icon = String.Format("ms-appx:///Assets/Weather/{0}.png", tempDayWeather.weather[0].icon);
                Dw.Description = tempDayWeather.weather[0].description + " | ";
                Dw.Temp = tempDayWeather.temp.min.ToString()+" / " + tempDayWeather.temp.max.ToString();
                System.DateTime tDate = new DateTime(1970, 1, 1, 0, 0, 0, 0, System.DateTimeKind.Utc);
                Dw.WeatherDate = tDate.AddSeconds(tempDayWeather.dt).ToString("dd-MMM") + " | ";
                WeatherList.Add(Dw);
            }
            WeatherListB.ItemsSource = WeatherList;
            #endregion
        }
    }
}

    
