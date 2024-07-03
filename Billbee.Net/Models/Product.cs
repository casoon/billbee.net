using System.Collections.Generic;

namespace Billbee.Net.Models;

/// <summary>
///     Defines a product/article in Billbee.
/// </summary>
public class Product
{
    /// <summary>
    ///     Gets or sets the text to display in the invoice.
    /// </summary>
    public List<MultiLanguageString> InvoiceText { get; set; }

    /// <summary>
    ///     Gets or sets the name of the manufacturer, if given.
    /// </summary>
    public string Manufacturer { get; set; }

    /// <summary>
    ///     Gets or sets the internal ID of this product.
    /// </summary>
    public long? Id { get; set; }

    /// <summary>
    ///     Gets or sets the name of the product.
    /// </summary>
    public List<MultiLanguageString> Title { get; set; }

    /// <summary>
    ///     Gets or sets the description of the product.
    /// </summary>
    public List<MultiLanguageString> Description { get; set; }

    /// <summary>
    ///     Gets or sets the short description of the product to show in summaries.
    /// </summary>
    public List<MultiLanguageString> ShortDescription { get; set; }

    /// <summary>
    ///     Gets or sets the basic attributes to define this product.
    /// </summary>
    public List<MultiLanguageString> BasicAttributes { get; set; }

    /// <summary>
    ///     Gets or sets the images of this product.
    /// </summary>
    public List<ArticleImage> Images { get; set; }

    /// <summary>
    ///     Gets or sets the index of the correct VAT rate to attach to this product.
    /// </summary>
    public byte VatIndex { get; set; }

    /// <summary>
    ///     Gets or sets the gross price of this product.
    /// </summary>
    public decimal Price { get; set; }

    /// <summary>
    ///     Gets or sets the cost price of the product, if applicable.
    /// </summary>
    public decimal? CostPrice { get; set; }

    /// <summary>
    ///     Gets or sets the first VAT rate.
    /// </summary>
    public decimal Vat1Rate { get; set; }

    /// <summary>
    ///     Gets or sets the second VAT rate.
    /// </summary>
    public decimal Vat2Rate { get; set; }

    /// <summary>
    ///     Gets or sets the desired stock amount for this article.
    /// </summary>
    public decimal? StockDesired { get; set; }

    /// <summary>
    ///     Gets or sets the current stock amount for this article.
    /// </summary>
    public decimal? StockCurrent { get; set; }

    /// <summary>
    ///     Gets or sets the stock warning level to alert when stock is low.
    /// </summary>
    public decimal? StockWarning { get; set; }

    /// <summary>
    ///     Gets or sets the stock keeping unit (SKU) of the product.
    /// </summary>
    public string SKU { get; set; }

    /// <summary>
    ///     Gets or sets the European Article Number (EAN) of the product.
    /// </summary>
    public string EAN { get; set; }

    /// <summary>
    ///     Gets or sets the list of materials this product consists of.
    /// </summary>
    public List<MultiLanguageString> Materials { get; set; }

    /// <summary>
    ///     Gets or sets the list of tags marking this product.
    /// </summary>
    public List<MultiLanguageString> Tags { get; set; }

    /// <summary>
    ///     Gets or sets the sources this article is attached to.
    /// </summary>
    public List<ArticleSource> Sources { get; set; }

    /// <summary>
    ///     Gets or sets the gross weight of this article.
    /// </summary>
    public int? Weight { get; set; }

    /// <summary>
    ///     Gets or sets the net weight of this article.
    /// </summary>
    public int? WeightNet { get; set; }

    /// <summary>
    ///     Gets or sets the stock code where this article is stored.
    /// </summary>
    public string StockCode { get; set; }

    /// <summary>
    ///     Gets or sets the number of items to reduce from stock per sale.
    /// </summary>
    public decimal? StockReduceItemsPerSale { get; set; }

    /// <summary>
    ///     Gets or sets the list of stock articles.
    /// </summary>
    public List<StockArticle> Stocks { get; set; }

    /// <summary>
    ///     Gets or sets the first category of the article.
    /// </summary>
    public ArticleCategory Category1 { get; set; }

    /// <summary>
    ///     Gets or sets the second category of the article.
    /// </summary>
    public ArticleCategory Category2 { get; set; }

    /// <summary>
    ///     Gets or sets the third category of the article.
    /// </summary>
    public ArticleCategory Category3 { get; set; }

    /// <summary>
    ///     Gets or sets the type of the article.
    /// </summary>
    public byte Type { get; set; }

    /// <summary>
    ///     Gets or sets the unit of the article.
    /// </summary>
    public short? Unit { get; set; }

    /// <summary>
    ///     Gets or sets the number of units per item.
    /// </summary>
    public decimal? UnitsPerItem { get; set; }

    /// <summary>
    ///     Gets or sets the sold amount of the article.
    /// </summary>
    public decimal? SoldAmount { get; set; }

    /// <summary>
    ///     Gets or sets the total gross sales of the article.
    /// </summary>
    public decimal? SoldSumGross { get; set; }

    /// <summary>
    ///     Gets or sets the total net sales of the article.
    /// </summary>
    public decimal? SoldSumNet { get; set; }

    /// <summary>
    ///     Gets or sets the total net sales of the article for the last 30 days.
    /// </summary>
    public decimal? SoldSumNetLast30Days { get; set; }

    /// <summary>
    ///     Gets or sets the total gross sales of the article for the last 30 days.
    /// </summary>
    public decimal? SoldSumGrossLast30Days { get; set; }

    /// <summary>
    ///     Gets or sets the sold amount of the article for the last 30 days.
    /// </summary>
    public decimal? SoldAmountLast30Days { get; set; }

    /// <summary>
    ///     Gets or sets the ID of the shipping product this article is bundled with.
    /// </summary>
    public long? ShippingProductId { get; set; }

    /// <summary>
    ///     Gets or sets a value indicating whether the article is digital.
    /// </summary>
    public bool IsDigital { get; set; }

    /// <summary>
    ///     Gets or sets a value indicating whether the article is customizable.
    /// </summary>
    public bool IsCustomizable { get; set; }

    /// <summary>
    ///     Gets or sets the delivery time of the article.
    /// </summary>
    public byte? DeliveryTime { get; set; }

    /// <summary>
    ///     Gets or sets the recipient of the article.
    /// </summary>
    public byte? Recipient { get; set; }

    /// <summary>
    ///     Gets or sets the occasion for which the article is intended.
    /// </summary>
    public byte? Occasion { get; set; }

    /// <summary>
    ///     Gets or sets the country of origin of the article.
    /// </summary>
    public string CountryOfOrigin { get; set; }

    /// <summary>
    ///     Gets or sets the export description of the article.
    /// </summary>
    public string ExportDescription { get; set; }

    /// <summary>
    ///     Gets or sets the TARIC number of the article.
    /// </summary>
    public string TaricNumber { get; set; }

    /// <summary>
    ///     Gets or sets the custom fields of the article.
    /// </summary>
    public List<ArticleCustomFieldValue> CustomFields { get; set; } = new();

    /// <summary>
    ///     Gets or sets a value indicating whether the article is deactivated.
    /// </summary>
    public bool? IsDeactivated { get; set; }
}