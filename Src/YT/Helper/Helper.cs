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
    public class Helper
    {
        public List<string> stations;

        public static async /*Task<Model.Route>*/ Task<List<Route>> GetWeather(string lat,string lon)
        {

            //Лист для возврата расписания
            //A list to return the schedule in list
            List<Route> schedule = new List<Route>();

            using (var httpClient = new HttpClient())
            {
                var response = await httpClient.GetAsync(Common.Common.APIRequest(lat, lon));
                var json = await response.Content.ReadAsStringAsync();

                if(response.StatusCode == System.Net.HttpStatusCode.OK) // 200 - OK
                {

                    /*
                    try
                    {
                        Route routes = JsonConvert.DeserializeObject<Route>(resultText);
                        return routes;
                    }
                    catch(Exception ex)
                    {
                        Debug.WriteLine(resultText);
                        return null;
                    }
                    */


                    //Парсим ответ
                    dynamic responce = JObject.Parse(json);
                    int length = 98;
                    try
                    {
                        Route route = new Route();
                        //We are collecting all the recordings and move them to list
                        //В цикле собираем все записи и переносим их в вид списка
                        for (int i = 0; i < length; i++)
                        {
                            //Route route = new Route();
                            //if (responce.schedule[i].direction == "прибытие")
                            //{ 
                            //    route.arrival = responce.schedule[i].arrival; 
                            //}
                            //else 
                            //{ 
                                route.depart = route.depart + " | "
                                + responce.schedule[i].departure; 
                            //}
                            
                            //schedule.Add(route);
                        }//for

                        schedule.Add(route);


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
