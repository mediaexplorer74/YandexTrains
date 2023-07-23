using System;

namespace YandexTrains.DataProvider
{
    internal class RestRequest : IRestRequest
    {
        private string v;

        public RestRequest(string v)
        {
            this.v = v;
        }

        public void AddParameter(string v1, string v2, object getOrPost)
        {
            //throw new NotImplementedException();
        }

        internal void AddHeader(string v1, string v2)
        {
            //throw new NotImplementedException();
        }

        internal void AddParameter(string v1, string v2)
        {
            //throw new NotImplementedException();
        }

        internal void AddQueryParameter(string v1, string v2)
        {
            //throw new NotImplementedException();
        }

        void IRestRequest.AddHeader(string v1, string v2)
        {
            //throw new NotImplementedException();
        }
    }
}