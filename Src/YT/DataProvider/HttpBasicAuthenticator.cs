namespace YandexTrains.DataProvider
{
    internal class HttpBasicAuthenticator
    {
        private string api_clientid;
        private string api_secret;

        public HttpBasicAuthenticator(string api_clientid, string api_secret)
        {
            this.api_clientid = api_clientid;
            this.api_secret = api_secret;
        }
    }
}