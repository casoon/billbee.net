using System.Text.Json;

namespace Billbee.Net.Models;

/// <summary>
///     Defines the sources in external systems to which this article is attached.
/// </summary>
public class ArticleSource
{
    /// <summary>
    ///     Gets or sets the name of the source.
    /// </summary>
    public string Source { get; set; }

    /// <summary>
    ///     Gets or sets the ID on the source.
    /// </summary>
    public string SourceId { get; set; }

    /// <summary>
    ///     Gets or sets the internal ID of this article source definition.
    /// </summary>
    public long Id { get; set; }

    /// <summary>
    ///     Gets or sets the name of the API account this source belongs to.
    /// </summary>
    public string ApiAccountName { get; set; }

    /// <summary>
    ///     Gets or sets the ID of the API account this source belongs to.
    /// </summary>
    public long? ApiAccountId { get; set; }

    /// <summary>
    ///     Gets or sets the export factor.
    /// </summary>
    public decimal? ExportFactor { get; set; }

    /// <summary>
    ///     Gets or sets a value indicating whether stock synchronization is inactive.
    /// </summary>
    public bool? StockSyncInactive { get; set; }

    /// <summary>
    ///     Gets or sets the minimum stock synchronization level.
    /// </summary>
    public decimal? StockSyncMin { get; set; }

    /// <summary>
    ///     Gets or sets the maximum stock synchronization level.
    /// </summary>
    public decimal? StockSyncMax { get; set; }

    /// <summary>
    ///     Gets or sets the number of units per item.
    /// </summary>
    public decimal? UnitsPerItem { get; set; }

    /// <summary>
    ///     Gets or sets custom properties for this article source.
    /// </summary>
    public JsonElement Custom { get; set; }
}