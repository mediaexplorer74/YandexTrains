using System;
using YandexTrains.ResponseModels.DepartureBoard;
using YandexTrains.ResponseModels.TripPlanner;
//using RestSharp.Deserializers;

namespace YandexTrains.ResponseModels
{
    public class AccessTokenResponse
    {
        //[DeserializeAs(Name = "scope")]
        public string Scope { get; set; }

        //[DeserializeAs(Name = "token_type")] 
        public string TokenType { get; set; }

        //[DeserializeAs(Name = "expires_in")] 
        public int Expires { get; set; }

        //[DeserializeAs(Name = "access_token")] 
        public Guid Token { get; set; }
        public TripListResponse TripList { get; internal set; }
        public LocationListResponse LocationList { get; internal set; }
        public DepartureBoardResponse DepartureBoard { get; internal set; }
    }
}
