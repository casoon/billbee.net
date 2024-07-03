namespace Billbee.Net.Models;

/// <summary>
///     Represents a cloud storage configuration.
/// </summary>
public class CloudStorage
{
    /// <summary>
    ///     Gets or sets the unique identifier for the cloud storage.
    /// </summary>
    public long Id { get; set; }

    /// <summary>
    ///     Gets or sets the name of the cloud storage.
    /// </summary>
    public string Name { get; set; }

    /// <summary>
    ///     Gets or sets the type of the cloud storage.
    /// </summary>
    public string Type { get; set; }

    /// <summary>
    ///     Gets or sets a value indicating whether the cloud storage is used as a printer.
    /// </summary>
    public bool UsedAsPrinter { get; set; }
}