using System;
//using RestSharp.Deserializers;

namespace YandexTrains.ResponseModels
{
    public class LocationListResponseRoot
    {
        //[DeserializeAs(Name = "LocationList")]
        public LocationListResponse LocationList { get; set; }
    }
}
