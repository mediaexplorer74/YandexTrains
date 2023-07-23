using System.Threading.Tasks;
using System;
using YandexTrains.Models;

namespace YandexTrains.DataProvider
{
    public interface IAccessTokenProvider
    {
        Task<AccessToken> GetAccessTokenAsync();
    }
}
