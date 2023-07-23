using YandexTrains.ResponseModels;

namespace YandexTrains.DataProvider
{
    internal interface IRestResponse<T>
    {
        AccessTokenResponse Data { get; }
        object StatusCode { get; set; }
    }
}