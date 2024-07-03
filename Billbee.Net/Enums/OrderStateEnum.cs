namespace Billbee.Net.Enums;

/// <summary>
///     Represents the possible states of an order.
/// </summary>
public enum OrderStateEnum
{
    /// <summary>
    ///     Order has been placed.
    /// </summary>
    Bestellt = 1,

    /// <summary>
    ///     Order has been confirmed.
    /// </summary>
    Bestaetigt = 2,

    /// <summary>
    ///     Payment has been received for the order.
    /// </summary>
    Zahlung_erhalten = 3,

    /// <summary>
    ///     Order has been shipped.
    /// </summary>
    Versendet = 4,

    /// <summary>
    ///     Order is in complaint or return process.
    /// </summary>
    Reklamation = 5,

    /// <summary>
    ///     Order has been deleted.
    /// </summary>
    Geloescht = 6,

    /// <summary>
    ///     Order has been completed.
    /// </summary>
    Abgeschlossen = 7,

    /// <summary>
    ///     Order has been canceled.
    /// </summary>
    Storniert = 8,

    /// <summary>
    ///     Order has been archived.
    /// </summary>
    Archiviert = 9,

    /// <summary>
    ///     Order has been rated.
    /// </summary>
    Rated = 10,

    /// <summary>
    ///     First reminder has been sent for the order.
    /// </summary>
    Mahnung = 11,

    /// <summary>
    ///     Second reminder has been sent for the order.
    /// </summary>
    Mahnung2 = 12,

    /// <summary>
    ///     Order has been packed.
    /// </summary>
    Gepackt = 13,

    /// <summary>
    ///     Order has been offered.
    /// </summary>
    Angeboten = 14,

    /// <summary>
    ///     Payment reminder has been sent for the order.
    /// </summary>
    Zahlungserinnerung = 15,

    /// <summary>
    ///     Order is in the fulfillment process.
    /// </summary>
    Im_Fulfillment = 16
}