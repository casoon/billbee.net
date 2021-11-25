using System;
namespace Billbee.Net.Responses
{
    public abstract class Paging
    {
        public int Page { get; set; }

        public int TotalPages { get; set; }

        public int TotalRows { get; set; }

        public int PageSize { get; set; }

    }
}

