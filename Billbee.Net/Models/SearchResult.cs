using System.Collections.Generic;

namespace Billbee.Net.Models;

/// <summary>
///     Container to store the results of a search query.
/// </summary>
public class SearchResult
{
    /// <summary>
    ///     Gets or sets the list of products matching the search query.
    /// </summary>
    public List<ProductSearchResult> Products { get; set; }

    /// <summary>
    ///     Gets or sets the list of orders matching the search query.
    /// </summary>
    public List<OrderSearchResult> Orders { get; set; }

    /// <summary>
    ///     Gets or sets the list of customers matching the search query.
    /// </summary>
    public List<CustomerSearchResult> Customers { get; set; }
}