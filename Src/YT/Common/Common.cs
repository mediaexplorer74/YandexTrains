using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Collections.Specialized.BitVector32;

namespace YT.Common
{
    public class Common
    {
        public static string API_LINK = $"https://api.rasp.yandex.net/v3.0/schedule/";
        public static string API_KEY = $"970ac53c-a84f-4818-99a7-a52b5ceff6b2";
        public static string station_code = $"s9881697"; // Olgino
        public static string lon = "55.05";
        public static string lat = "38.50";
      
        public static string APIRequest(string lat,string lon)
        {
            var cur_date = DateTime.Now.ToString("YYYYMMDD");//("dd MMMM yyyy HH:mm");

            StringBuilder strBuilder = new StringBuilder(API_LINK);
                       
            //...
            strBuilder.AppendFormat("?apikey={0}&station={1}&transport_types=suburban&direction=на%20Москву",//&date={2}", 
                API_KEY, station_code);//, cur_date);
            
            return strBuilder.ToString();
        }

        public static DateTime ConvertUnixTimeToDateTime(double unix)
        {
            DateTime dt = new DateTime(1970, 1, 1, 0, 0, 0, 0, System.DateTimeKind.Utc);
            dt = dt.AddSeconds(unix).ToLocalTime();
            return dt;
        }

    }
}
