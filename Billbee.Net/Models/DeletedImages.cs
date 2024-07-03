using System.Collections.Generic;

namespace Billbee.Net.Models;

/// <summary>
///     Represents the result of an image deletion request, containing lists of deleted and not found images.
/// </summary>
public class DeletedImages
{
    /// <summary>
    ///     Gets or sets the list of image IDs that were successfully deleted.
    /// </summary>
    public List<int> Deleted { get; set; }

    /// <summary>
    ///     Gets or sets the list of image IDs that were not found.
    /// </summary>
    public List<int> NotFound { get; set; }
}