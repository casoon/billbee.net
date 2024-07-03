using System.Collections.Generic;

namespace Billbee.Net.Models;

/// <summary>
///     Container to store the search parameters.
/// </summary>
public class Search
{
    /// <summary>
    ///     Gets or sets the list of types to search in. Possible values are "order", "product", and/or "customer".
    /// </summary>
    public List<string> Types { get; set; }

    /// <summary>
    ///     Gets or sets the search term.
    /// </summary>
    public string Term { get; set; }
}