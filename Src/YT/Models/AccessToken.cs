using System;
using System.Diagnostics;
using YandexTrains.ResponseModels;

namespace YandexTrains.Models
{
    public class AccessToken
    {
        public string Scope { get; set; }
        public string Type { get; set; }
        public Guid Token { get; set; }
        public DateTime CreatedDateTime { get; set; }
        public DateTime ExpiresDateTime { get; set; }

        public AccessToken(AccessTokenResponse accessTokenResponseModel)
        {
            // init (default)
            Scope = "";
            Type = "";
            Token = Guid.Empty;
            DateTime now = DateTime.Now;
            CreatedDateTime = now;
            ExpiresDateTime = now;

            if (accessTokenResponseModel != null)
            {
                Scope = accessTokenResponseModel.Scope;
                Type = accessTokenResponseModel.TokenType;
                Token = accessTokenResponseModel.Token;
                now = DateTime.Now;
                CreatedDateTime = now;
                ExpiresDateTime = now.AddSeconds(accessTokenResponseModel.Expires);
            }
            else
            {
                Debug.WriteLine("[!] accessTokenResponseModel = null");
            }
        }

        // Used on file retrieval
        public AccessToken()
        {
        }
    }
}
