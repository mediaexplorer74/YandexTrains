using System;
using System.Threading.Tasks;
using YandexTrains.Models;
using YandexTrains.Models.DepartureBoard;
using YandexTrains.Models.TripPlanner;

namespace YandexTrains.DataProvider
{
    public interface ITripPlannerProvider
    {
        bool IsAccessTokenExpired { get; }

        Task<LocationList> GetLocationListAsync(string query);
        Task<DepartureBoard> GetDepartureBoardAsync(string stopId);
        Task<DepartureBoard> GetDepartureBoardAsync(string stopId, DateTime dateTime);
        Task<TripList> GetTripListAsync(string originStopId, string destinationStopId);
        Task<TripList> GetTripListAsync(string originStopId, string destinationStopId,
            DateTime dateTime, bool isSearchForArrival = false);

        void SetToken(AccessToken newToken);
    }
}
