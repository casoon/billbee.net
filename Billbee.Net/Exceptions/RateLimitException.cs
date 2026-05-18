using System;

namespace Billbee.Net.Exceptions;

public class RateLimitException : Exception
{
    public RateLimitException() : base("Rate limit exceeded (HTTP 429)") { }
}
