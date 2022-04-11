using System;
using System.Collections.Generic;
using System.Diagnostics;
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

// GetTime namespace
namespace GetTime
{
    /// <summary>
    /// Пустая страница, которую можно использовать саму по себе или для перехода внутри фрейма.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        public MainPage()
        {
            this.InitializeComponent();

            // TODO *******************
            //Номер станции в системе Яндекс.Расписания
            //Station ID from yandex.schedules
            string date;

            SuperWriteLine("Дата в формате YYYY-MM-DD : 2022-04-18");

            date = "2022-04-18";//Console.ReadLine();

            DateTime enteredDate = DateTime.Parse(date);

            SuperWriteLine("Станция 1: Каланчевская (код 2001005)");

            //string station1 = DB.Find_station_code(Convert.ToString(Console.ReadLine())).code;
            string station1 = "s2001005"; //DB.Find_station_code("Каланчовская").code;

            SuperWriteLine("Станция 2: Москва Курская (код 2000001)");

            //string station2 = DB.Find_station_code(Convert.ToString(Console.ReadLine())).code;
            string station2 = "s2000001";//DB.Find_station_code("Москва Курская").code;

            if (station1 is null || station2 is null)
            {
                SuperWriteLine("По вашему запросу не найдено станций");
            }

            //Если введеная дата раньше сегодня, закрываемся
            //If entered date is earlier than today we finish or show an error
            SuperWriteLine("Получаем данные от Яндекс-Расписаний...");
            
            //Collecting data from yandex (this will take a couple of seconds)
            List<Schedule.Route> schedule = new List<Schedule.Route>();
            schedule = Schedule.station_timetable_get(date, station1);

            // ...
            foreach (Schedule.Route route in schedule)
            {
                if (route.depart != null)
                {
                    SuperWriteLine("--> " + route.depart);
                }
                else
                {
                    SuperWriteLine("<-- " + route.arrival);
                }
                SuperWriteLine("#####");
            }

            //Schedule.get_stationID("58.816280", "30.329888");
            List<Schedule.Route> Route_list = new List<Schedule.Route>();
            Route_list = Schedule.route_time_get(date, station1, station2);
            foreach (Schedule.Route route in Route_list)
            {
                SuperWriteLine("####" + route.title + "####");
                SuperWriteLine(route.depart);
                SuperWriteLine(route.arrival);
            }
            //Schedule.route_get_station();

            // ************************

        }//MainPage() end

        public void SuperWriteLine(String message)
        {
           
            OutputBox.Items.Add( new { message } );
        }

    }//MainPage class end


}//namespace end

