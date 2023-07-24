using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Devices.Geolocation;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.Foundation.Metadata;
using Windows.UI.ViewManagement;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Media.Imaging;
using Windows.UI.Xaml.Navigation;


namespace YT
{
    
    public sealed partial class MainPage : Page
    {
        string Lat, Lng;
        public MainPage()
        {
            this.InitializeComponent();
            HideStatusBar();
        }

        private async void HideStatusBar()
        {
            if (ApiInformation.IsApiContractPresent("Windows.Phone.PhoneContract", 1, 0))
            {
                var statusBar = StatusBar.GetForCurrentView();
                await statusBar.HideAsync();
            }
        }

        private async void btnGetWeather_Click(object sender, RoutedEventArgs e)
        {
            progressRing.IsActive = true;
            var geoLocator = new Geolocator();
            geoLocator.DesiredAccuracy = PositionAccuracy.High;

            try
            {
                Geoposition pos = await geoLocator.GetGeopositionAsync();

                Lat = pos.Coordinate.Point.Position.Latitude.ToString();
                Lng = pos.Coordinate.Point.Position.Longitude.ToString();

            }
            catch
            {
                float Latitude = 55.05f;
                float Longitude = 38.5f;
                Lat = Latitude.ToString();
                Lng = Longitude.ToString();
            }



            List<Model.Route> many_data = await Helper.Helper.GetWeather(Lat, Lng);

            Model.Route data = null;

            if (many_data != null)
            {
                data = many_data[0];
            }

            if (data != null)
            {
                txtCity.Text = $"{data.depart},{data.title},{data.arrival}";
                txtLastUpdate.Text = $"Last updated : {DateTime.Now.ToString("dd MMMM yyyy HH:mm")}";

                BitmapImage image = default;
                    //new BitmapImage(new Uri($"http://openweathermap.org/img/w/{data.weather[0].icon}.png", 
                    //  UriKind.Absolute));
                imgWeather.Source = image;

                txtDescription.Text = "-";//$"{data.weather[0].description}";
                txtHumidity.Text = "-";//$"Humidity : {data.main.humidity}%";
                txtTime.Text = "-";//$"{Common.Common.ConvertUnixTimeToDateTime(data.sys.sunrise).ToString("HH:mm")}/ {Common.Common.ConvertUnixTimeToDateTime(data.sys.sunset).ToString("HH:mm")}";

                txtCel.Text = "-";//$"{data.main.temp} °C";
            }
            progressRing.IsActive = false;
        }
    }
}
