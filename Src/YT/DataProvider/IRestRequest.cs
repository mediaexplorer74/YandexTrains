namespace YandexTrains.DataProvider
{
    internal interface IRestRequest
    {
        void AddHeader(string v1, string v2);
        void AddParameter(string v1, string v2, object getOrPost);
    }
}