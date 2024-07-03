namespace Billbee.Net.Enums;

/// <summary>
///     Represents the possible VAT (Value Added Tax) modes.
/// </summary>
public enum VatModeEnum : byte
{
    /// <summary>
    ///     VAT is displayed.
    /// </summary>
    DisplayVat = 0,

    /// <summary>
    ///     No VAT for small businesses (Kleinunternehmer).
    /// </summary>
    NoVatKleinunternehmer = 1,

    /// <summary>
    ///     No VAT for intra-community supply.
    /// </summary>
    NoVatInnergemeinschaftlicheLieferung = 2,

    /// <summary>
    ///     No VAT for export to third countries (Ausfuhr Drittland).
    /// </summary>
    NoVatAusfuhrDrittland = 3,

    /// <summary>
    ///     No VAT due to differential taxation (Differenzbesteuerung).
    /// </summary>
    NoVatDifferenzbesteuerung = 4,

    /// <summary>
    ///     Placeholder for the last enum entry, used for validation.
    /// </summary>
    LastEnumEntry = 5
}