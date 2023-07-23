using System.Threading.Tasks;

namespace YandexTrains.DataProvider
{
    internal interface IRestClient
    {
        HttpBasicAuthenticator Authenticator { get; set; }

        Task<IRestResponse<T>> ExecuteTaskAsync<T>(IRestRequest request, object Post);
    }
}