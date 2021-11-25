using System;
namespace Billbee.Net.Exceptions
{
    public class NotFoundException : ApplicationException
    {
        public NotFoundException(string message, Exception e) : base(message, e)
        { }

        public NotFoundException(string message) : base(message)
        { }
    }
}

