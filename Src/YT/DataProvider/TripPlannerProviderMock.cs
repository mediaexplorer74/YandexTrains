using YandexTrains.Models;
using YandexTrains.Models.DepartureBoard;
using YandexTrains.Models.TripPlanner;
using YandexTrains.ResponseModels;
using YandexTrains.ResponseModels.TripPlanner;
using YandexTrains.Utilities;
//using RestSharp;
//using RestSharp.Deserializers;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Xml.Linq;
using Windows.Media.Protection.PlayReady;

namespace YandexTrains.DataProvider
{
//#pragma warning disable
    public class TripPlannerProviderMock : ITripPlannerProvider
    {

        private const string _dateFormat = "yyyy-MM-dd";
        private const string _timeFormat = "HH:mm";

        private readonly RestClient _client;
        
        private AccessToken _accessToken;

        private ILog _logger;
        public ILog Logger
        {
            set => _logger = value;
        }

        private AccessToken token;

        public TripPlannerProviderMock(AccessToken token)
        {
            this.token = token;
        }

        public bool IsAccessTokenExpired
        {
            get
            {
                return false;
            }
        }

        public async Task<DepartureBoard> GetDepartureBoardAsync(string stopId)
        {
            throw new NotImplementedException();
        }

        public async Task<DepartureBoard> GetDepartureBoardAsync(string stopId,
            DateTime dateTime)
        {
            throw new NotImplementedException();
        }

        public async Task<LocationList> GetLocationListAsync(string query)
        {
            await Task.Delay(new Random().Next(10, 10001));

            return new LocationList(new ResponseModels.LocationListResponse
            {
                ServerDate = "2023-07-23", //yyyy-mm-dd
                ServerTime = "23:55",
                StopLocations = new[]
                {
                    new StopLocationResponse
                    {
                        Id = "001",//Guid.NewGuid().ToString(),
                        Name = "Street name, City",
                        Index = 1
                    },
                    new StopLocationResponse
                    {
                        Id = "002",//Guid.NewGuid().ToString(),
                        Name = "Goteborg Central, Goteborg",//"Göteborg Central, Göteborg",
                        Index = 2
                    },
                    new StopLocationResponse
                    {
                        Id = "003",//Guid.NewGuid().ToString(),
                        Name = "Svingeln, Goteborg",//"Svingeln, Göteborg",
                        Index = 3
                    },
                }
            });
        }

        public async Task<TripList> GetTripListAsync(string originStopId, 
            string destinationStopId)
        {
            //throw new NotImplementedException();
            return await GetTripListAsync(originStopId, destinationStopId, DateTime.Now);
        }

        public async Task<TripList> GetTripListAsync(string originStopId, 
            string destinationStopId, DateTime dateTime, bool isSearchForArrival = false)
        {
            //throw new NotImplementedException();
            
            Log($"{nameof(GetTripListAsync)}: Requesting trips " +
               $"for {nameof(originStopId)} {originStopId} and" +
               $" {nameof(destinationStopId)} {destinationStopId}",
               "Request");

            var request = new RestRequest("/trip");
            //request.AddHeader("Authorization", $"{_accessToken.Type} {_accessToken.Token}");
            request.AddQueryParameter("originId", originStopId);
            request.AddQueryParameter("destId", destinationStopId);
            request.AddQueryParameter("date", dateTime.ToString("yyyy-MM-dd"));
            request.AddQueryParameter("time", dateTime.ToString("HH:mm"));

            request.AddQueryParameter("searchForArrival",
                (isSearchForArrival ? 1 : 0).ToString()); // Convert bool to bit

            request.AddQueryParameter("format", "json");


            // TripListResponse TripListResponseM = new TripListResponse() {
            //     ServerDate = "2023-07-23",//dateTime.ToString("yyyy-MM-dd"),
            //     ServerTime = "12:00"//dateTime.ToString("HH:mm")
            // };


            List<LegResponse> LR = new List<LegResponse>();

            LegResponse leg_item = new LegResponse();

            leg_item.Id = "1";
            leg_item.Name = "TestName";
            leg_item.JourneyNumber = "M01";

            leg_item.SName = "SName";
            leg_item.Stroke = "Stroke";
            leg_item.Type = "REG";

            leg_item.Destination = new PointResponse() 
            {
                Id = "007",
                Type = "TRN",
                Name = "Train",
                Time = "15:00",
                RealisticTime = "15:00",
                Date = "2023-07-23",
                RealisticDate = "2023-07-23",
                Track = "C"
            };

            leg_item.Origin = new PointResponse()
            {
                Id = "007",
                Type = "TRN",
                Name = "Train",
                Time = "10:00",
                RealisticTime = "10:00",
                Date = "2023-07-23",
                RealisticDate = "2023-07-23",
                Track = "C"
            };
            leg_item.Accessibility = "Acc";
            leg_item.ForegroundColor = "Red";
            leg_item.BackgroundColor = "Green";
            leg_item.Direction = "East";
           

            LR.Add(leg_item);

            List<TripResponse> TR = new List<TripResponse>();

            TripResponse trip_item = new TripResponse()
            {
                Legs = LR
            };

            TR.Add(trip_item);

            var TLR = new TripListResponse()
            {
                ServerDate = "2023-07-23",//dateTime.ToString("yyyy-MM-dd"),
                ServerTime = "12:00",//dateTime.ToString("HH:mm")
                Trips = TR//default
            };

            //IRestResponse<TripListRoot> 
            var response =
                //await _client.ExecuteTaskAsync<TripListRoot>(request, Method.GET);

                new RestResponse<TripListRoot>
                {
                    Data = new TripListRoot
                    {
                        //TripList = default

                        TripList = TLR
                       //   new TripListResponse()
                       //   {
                       //       ServerDate = "2023-07-23",//dateTime.ToString("yyyy-MM-dd"),
                       //       ServerTime = "12:00",//dateTime.ToString("HH:mm")
                       //       Trips = default
                       //   }

                   }  
                };

            Log($"{nameof(GetTripListAsync)}: {response.StatusCode}", "Response");

            return new TripList(response.Data.TripList);
        }


        public void SetToken(AccessToken newToken)
        {
            _accessToken = token;
        }

        private void Log(string message)
        {
            _logger?.Log(message);
        }

        private void Log(string message, string category)
        {
            _logger?.Log(message, category);
        }
    }
//#pragma warning restore
}
