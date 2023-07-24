//Experimental

using System;
using System.Net.Http;
using System.Collections.Generic;
using Newtonsoft.Json;
using System.IO;
using Microsoft.VisualBasic;
using System.Diagnostics;

namespace YT.Helper
{
    public class HelperPi
    {
        private static string[] codes_dict;

        public static void Init()
        {
            string api_key = "3d4db511-c803-4569-a638-e0babb6cbccc";//"your_api_key";
            string api_url = "https://api.rasp.yandex.net/v3.0/schedule/";
            string to_code = "to_code";
            string from_code = "from_code";

            FindCode(to_code);
            SchBetweenRoutes(api_key, api_url, to_code, from_code);
            ReqStationCodes(api_key);
        }

        public static void FindCode(string to_inp)
        {
            string code = default;//codes_dict[to_inp];
            Debug.WriteLine("code = " + code);
        }

        public static void SchBetweenRoutes(string api_key, string api_url, 
            string to_code, string from_code)
        {
            string format = "json";
            string from1 = from_code;
            string to = to_code;
            string lang = "ru";
            string date = DateTime.Now.ToString("yyyy-MM-dd");

            Dictionary<string, string> payload = new Dictionary<string, string>()
        {
            {"apikey", api_key},
            {"from", from1},
            {"to", to},
            {"format", format}
        };

            HttpClient client = new HttpClient();

            // api_url, ,new FormUrlEncodedContent(payload)
            HttpResponseMessage response = client.GetAsync(api_url).Result;


            string resp = response.Content.ReadAsStringAsync().Result;

            Debug.WriteLine(resp);
        }

        public static void ReqStationCodes(string api_key)
        {
            Dictionary<string, string> payload1 = new Dictionary<string, string>()
        {
            {"apikey", api_key},
            {"format", "json"}
        };

            HttpClient client = new HttpClient();
            HttpResponseMessage response = client.GetAsync(
                "https://api.rasp.yandex.net/v3.0/stations_list/" +
                "?apikey=3d4db511-c803-4569-a638-e0babb6cbccc&lang=ru_ru&format=json")
                .Result;

            string resp = response.Content.ReadAsStringAsync().Result;

            Dictionary<string, char> distros_dict = 
                JsonConvert.DeserializeObject<Dictionary<string, char>>(resp);
            
            List<object> doc = new List<object>();

            Dictionary<string, char> res_cd = new Dictionary<string, char>();


            //TODO
            /*
            foreach (Dictionary<string, char> cnt in distros_dict["countries"])
            {
                if (cnt["title"].ToString() == "Россия")
                {
                    Debug.WriteLine(cnt["title"]);

                    foreach (Dictionary<string, object> rg in cnt["regions"])
                    {
                        if (rg["title"].ToString() == "Республика Татарстан")
                        {
                            foreach (Dictionary<string, object> stl in rg["s"])
                            {
                                // do something with stl
                            }
                        }
                    }
                }
            }
            */
        }
    }
}


/*
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using YT.Model;

namespace YT.Helper
{
    public class HelperPi
    {
        public List<string> stations;

        public static async Task<List<Route>> GetWeather(string lat,string lon)
        {

            List<Route> schedule = new List<Route>();

            using (var httpClient = new HttpClient())
            {
                var response = await httpClient.GetAsync(Common.Common.APIRequest(lat, lon));
                var json = await response.Content.ReadAsStringAsync();

                if(response.StatusCode == System.Net.HttpStatusCode.OK) // 200 - OK
                {

                   dynamic responce = JObject.Parse(json);
                    int length = 98;
                    try
                    {
                        for (int i = 0; i < length; i++)
                        {
                            var route = new Route();
                            if (responce.schedule[i].direction == "прибытие")
                            { 
                                route.arrival = responce.schedule[i].arrival; 
                            }
                            else 
                            { 
                                route.depart = responce.schedule[i].departure; 
                            }
                            schedule.Add(route);
                        }
                        return schedule;
                    }
                    catch (Exception ex)
                    {
                        return schedule;
                    }

                }
                return null;
            }
        }
    }
}
*/


