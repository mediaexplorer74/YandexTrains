using System;
using System.Collections.Generic;
//using RestSharp.Deserializers;

namespace YandexTrains.ResponseModels.TripPlanner
{
    public class TripResponse
    {
        //[DeserializeAs(Name = "Leg")]
        public IEnumerable<LegResponse> Legs { get; set; }
    }
}
