using System;

namespace Logster.Logging
{
    public class LogEvent
    {
        private string _message;
        private string _timestamp;
        private object[]? _values;

        public string Message
        {
            get => _message;
            set => _message = value;
        }

        public LogEvent(string message, params object[]? values) => (_message, _timestamp, _values) = (message, DateTime.UtcNow.ToString(), values);
    }
}