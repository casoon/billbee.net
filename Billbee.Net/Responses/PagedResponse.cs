using System;
using System.Collections.Generic;

namespace Billbee.Net.Responses
{
    public class PagedResponse<T>
    {
        public class PagingInformation
        {
            public int Page { get; set; }

            public int TotalPages { get; set; }

            public int TotalRows { get; set; }

            public int PageSize { get; set; }

        }

        public int ErrorCode { get; set; }

        public string ErrorDescription { get; set; }

        public string ErrorMessage { get; set; }

        public PagingInformation Paging { get; set; }

        public List<T> Data { get; set; }
    }
}

