using System;

namespace YandexTrains.Utilities
{
    public interface ILog
    {
        void Log(object value);
        void Log(object value, string category);
    }
}
