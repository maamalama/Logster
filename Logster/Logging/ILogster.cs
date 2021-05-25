namespace Logster.Logging
{
    public interface ILogster
    {
        void Log(string message);
        void Debug(string message);
        void Debug(string message, params object[]? loggingParams);
    }
}