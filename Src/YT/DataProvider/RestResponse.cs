using YandexTrains.ResponseModels.TripPlanner;

namespace YandexTrains.DataProvider
{
    internal class RestResponse<T>
    {
        internal readonly object StatusCode;

        public TripListRoot Data { get; set; }
    }
}