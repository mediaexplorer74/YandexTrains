using System;
using System.Collections.Generic;
using System.Linq;
using YandexTrains.DataProvider;
using YandexTrains.ResponseModels.TripPlanner;
//using RestSharp;

namespace YandexTrains.Models.TripPlanner
{
    public class TripList
    {
        public DateTime ServerDateTime { get; set; }
        public IEnumerable<Trip> Trips { get; set; }

        public TripList(TripListResponse tripListResponseModel)
        {
            ServerDateTime = DateTime.ParseExact(string.Format("{0} {1}", 
                tripListResponseModel.ServerDate, tripListResponseModel.ServerTime),
                "yyyy-MM-dd HH:mm", System.Globalization.CultureInfo.InvariantCulture);


            // !!!!!!!!!!!!!!!!!!!!!!!!
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

            List<Step> LSteps = new List<Step>();

            Step step_item = new Step();

            step_item.FullName = "FullName";
            step_item.ShortName = "ShortName";
            step_item.JourneyNumber = "M01";

            
            step_item.Destination = new Destination()
            {
                Type = default,
                StopId = "StopId",
                StopName = "StopName",
                Track = "C"
            };

            step_item.Origin = new Origin()
            {
                Type = default,
                StopName = "TrainStop",
                StopId = "10",
                Track = "C"
            };
            step_item.Accessibility = "Acc";
            step_item.Direction = "East";

            LSteps.Add(step_item);

            List<Trip> trips = new List<Trip>();

            Trip tr_item = new Trip();

            tr_item.Steps = LSteps;
            
            trips.Add(tr_item);


            Trips = trips;//TripList(response.Data.TripList);

            // !!!!!!!!!!!!!!!!!!!!!!!!

            //Trips = tripListResponseModel.Trips.Select(trip => new Trip(trip));
        }
    }
}
