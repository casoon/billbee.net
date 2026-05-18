using System;

namespace Billbee.Net.Exceptions;

public class ServerErrorException : Exception
{
    public int StatusCode { get; }
    public ServerErrorException(int statusCode) : base($"Server error (HTTP {statusCode})")
    {
        StatusCode = statusCode;
    }
}
