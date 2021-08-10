using System;
using Logster.LogExpiration;

namespace Logster.Extensions
{
    public static class LogExtensions
    {
        public static void AddLogLifetime(this Logging.Logster logster, int seconds)
        {
            if(seconds > 0)
                logster.Expiration = new Expiration(TimeSpan.FromSeconds(seconds));
        }
    }
}