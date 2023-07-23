using YandexTrains.Models;
using YandexTrains.ResponseModels;
using YandexTrains.Utilities;
//using RestSharp;
//using RestSharp.Authenticators;
using System;
using System.Diagnostics;
using System.Threading.Tasks;
using Windows.Storage;

namespace YandexTrains.DataProvider
{
    /// <summary>
    /// Provides an access token for <see cref="TripPlannerProvider"/>
    /// </summary>
    public class AccessTokenProvider : IAccessTokenProvider
    {
        private readonly IRestClient _client;
        private ILog _logger;

        public ILog Logger
        {
            set => _logger = value;
        }

        public AccessTokenProvider()
        {
            try
            {
                _client = default;//new RestClient("https://api.vasttrafik.se/token");
            }
            catch (Exception ex)
            {
                Debug.WriteLine("[ex] access https://api.vasttrafik.se/token error: "
                    + ex.Message);
                _client = default;
            }
        }

        public async Task<AccessToken> GetAccessTokenAsync()
        {
            Log($"{nameof(GetAccessTokenAsync)}: Requesting access token", "Request");
            ApplicationDataContainer localStorage = ApplicationData.Current.LocalSettings;

            IRestRequest request = default;//new RestRequest();

            AccessToken accessToken = default;

            /*
            string api_clientid = "777";//localStorage.Values["Api_ClientId"].ToString();
            string api_secret = "888";//localStorage.Values["Api_Secret"].ToString();

            try
            {
                //_client.Authenticator = new HttpBasicAuthenticator(
                //api_clientid,
                //api_secret
                //);
            }
            catch (Exception ex)
            {
                Debug.WriteLine("[ex] GetAccessTokenAsync error: " + ex.Message);
                _client.Authenticator = default;
            }

            //request.AddHeader("Content-Type", "application/x-www-form-urlencoded");
            //request.AddParameter("grant_type", "client_credentials", 
            //    / * ParameterType.GetOrPost * / default);

            IRestResponse<AccessTokenResponse> response = default;

            try
            {
                response = await _client.ExecuteTaskAsync<AccessTokenResponse>(
                    request, / * Method.POST * / default);
            }
            catch (Exception ex)
            {
                Debug.WriteLine("[ex] POST AccessTokenRequest error: " + ex.Message);
                _client.Authenticator = default;
            }

            try
            {
                accessToken = new AccessToken(response.Data);
            }
            catch (Exception ex)
            {
                Debug.WriteLine("[ex] AccessToken error: " + ex.Message);
            }

            Log($"{nameof(GetAccessTokenAsync)}: {response.StatusCode}");
            */

            return accessToken;
        }

        private void Log(string message)
        {
            _logger?.Log(message);
        }

        private void Log(string message, string category)
        {
            _logger?.Log(message, category);
        }
    }
}
