using System;

namespace Logster.LogExpiration
{
    public class Expiration
    {
        public Expiration() : this(null)
        {
        }

        public Expiration(TimeSpan? expirationTime)
        {
            ExpirationTime = expirationTime;
        }

        public TimeSpan? ExpirationTime { get; }

        public override string ToString()
        {
            if (ExpirationTime != null) 
                return $"{ExpirationTime.Value.Seconds}";
            return "0";
        }
    }
}