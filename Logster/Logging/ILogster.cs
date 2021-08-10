using System;

namespace Logster.Logging
{
    public interface ILogster : IDisposable
    {
        void Log(string message);
        void Debug(string message);
        void Debug(string message, params object[]? loggingParams);
        string LoggerInformation();
    }
}