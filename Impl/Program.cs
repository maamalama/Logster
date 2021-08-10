using System;
using Logster.Extensions;
using Logger = Logster.Logging;

namespace Impl
{
    class Program
    {
        static void Main(string[] args)
        {
            var logger = new Logger.Logster();
            logger.AddLogLifetime(30);

            logger.Debug("First message");
            logger.Debug("Second message");
            logger.Debug("test");

            logger.Log("Log info");
            
            Console.WriteLine("====================");

            foreach (var log in logger.LogsByLevel(Logger.LoggingLevel.Debug))
            {
                Console.WriteLine(log.ToString());
            }

            Console.WriteLine("====================");
            Console.WriteLine("Only info");

            var logs = logger.LogsByLevel(Logger.LoggingLevel.Info);
            
            foreach (var log in logs)
            {
                Console.WriteLine(log.ToString());
            }

            Console.WriteLine(logger.LoggerInformation());

            Console.WriteLine("====================");
        }
    }
}