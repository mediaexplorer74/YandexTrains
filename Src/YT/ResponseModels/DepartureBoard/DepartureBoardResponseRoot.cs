using System;
//using RestSharp.Deserializers;

namespace YandexTrains.ResponseModels.DepartureBoard
{
    public class DepartureBoardResponseRoot
    {
        //[DeserializeAs(Name = "DepartureBoard")]
        public DepartureBoardResponse DepartureBoard { get; set; }
    }
}
