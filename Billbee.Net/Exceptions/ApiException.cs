using System;
namespace Billbee.Net.Exceptions
{
    public class ApiException : ApplicationException
    {
        public ApiException(string message, Exception e) : base(message, e)
        { }

        public ApiException(string message) : base(message)
        { }
    }
}

