using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace Logster.Logging
{
    public class Logster : ILogster
    {
        private Dictionary<LoggingLevel, List<LogEvent>> _inMemoryLog = new();
        public int Size { get; set; }
        public Logster()
        {
            _inMemoryLog.Add(LoggingLevel.Debug, new List<LogEvent>());
            _inMemoryLog.Add(LoggingLevel.Info, new List<LogEvent>());
            _inMemoryLog.Add(LoggingLevel.Warn, new List<LogEvent>());
        }

        public void Log(string message)
        {
            var logEvent = new LogEvent(message);
            Add(LoggingLevel.Info,logEvent);
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

        public IEnumerable<LogEvent> Logs(LoggingLevel level)
        {
            foreach (var log in _inMemoryLog)
            {
                lock (log.Value)
                    foreach (var evnt in log.Value)
                        yield return evnt;
            }
        }

        public IEnumerable<LogEvent> LogsByLevel(LoggingLevel level) => _inMemoryLog[level];

        private void Add(LoggingLevel loggingLevel, LogEvent logEvent)
        {
            logEvent.Level = loggingLevel;
            var list = _inMemoryLog[loggingLevel];

            lock(list)
                list.Add(logEvent);
        }
    }
}