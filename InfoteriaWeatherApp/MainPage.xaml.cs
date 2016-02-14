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

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace InfoteriaWeatherApp
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

        private async void Button_Click(object sender, RoutedEventArgs e)
        {
            string city = cityInput.Text;
            try
            {
                RootObject result = await WeatherAppHelper.GetWeather(cityInput.Text);
                string cityInfo = string.Format("Weather Inromation for your queried city {0}, {1}: ", result.city.name, result.city.country);
                string tempInfoTemplate = "Day Temparature: {0} C \n Night Temparature: {1} C \n Maximum Temparature: {2} C \n Minimum Temparature: {3} C";
                string tempMsg = string.Format(tempInfoTemplate, result.list[0].temp.day, result.list[0].temp.night, result.list[0].temp.max, result.list[0].temp.min);
                string weatherInfoTemplate = "Pressure is {0} hPA with humidity of {1}% and wind speed of {2} meter/sec towards {3} angle.";
                string weatherMsg = string.Format(weatherInfoTemplate, result.list[0].pressure, result.list[0].humidity, result.list[0].speed, result.list[0].deg);
                weatherUpdate.Text = cityInfo + "\n" + tempMsg + "\n\n\n" + weatherMsg;
            }
            catch (Exception ex)
            {
                weatherUpdate.Text = "Unable to get weather information. Please verify the city name and make sure internet connection is working and try again.";
            }
        }

    }
}
