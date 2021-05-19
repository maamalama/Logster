using System;
using System.Collections.Generic;

namespace Logster.Logging
{
    public class Logster : ILogster
    {
        private Dictionary<LoggingLevel, LogEvent> _inMemoryLog;

        public Logster()
        {
            _inMemoryLog = new();
        }
        
        public void Log(string message)
        {
            Console.WriteLine(message);
        }
        
        public void Debug(string message)
        {
            var logEvent = new LogEvent(message);
            Add(LoggingLevel.Debug,logEvent);
        }
        public void Debug(string message, params object[]? loggingParams)
        {
            var logEvent = new LogEvent(message, loggingParams);
        }

        public void AllLogs()
        {
            foreach (var log in _inMemoryLog)
            {
                Console.WriteLine($"{log.Key}: {log.Value.Message}");
            }
        }

        private void Add(LoggingLevel loggingLevel, LogEvent logEvent)
        {
            lock(_inMemoryLog)
                _inMemoryLog.Add(loggingLevel, logEvent);
        }
    }
}