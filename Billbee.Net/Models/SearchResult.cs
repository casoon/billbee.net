using System.Collections.Generic;

namespace Billbee.Net.Models
{
    public class SearchResult
    {
        public List<ProductSearchResult> Products { get; set; }
        public List<OrderSearchResult> Orders { get; set; }
        public List<CustomerSearchResult> Customers { get; set; }
    }
}