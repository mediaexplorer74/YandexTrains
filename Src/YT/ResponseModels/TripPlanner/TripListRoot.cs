using System;
//using RestSharp.Deserializers;

namespace YandexTrains.ResponseModels.TripPlanner
{
    public class TripListRoot
    {
        //[DeserializeAs(Name = "TripList")]
        public TripListResponse TripList { get; set; }
    }
}
