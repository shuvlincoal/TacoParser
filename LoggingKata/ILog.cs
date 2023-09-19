using System;
namespace LoggingKata
{
    public interface ILog   // : ITrackable??
    {
        void LogFatal(string log, Exception exception = null); //stubbed out methods....... 
        void LogError(string log, Exception exception = null);
        void LogWarning(string log);
        void LogInfo(string log);
        void LogDebug(string log);
    }
}
