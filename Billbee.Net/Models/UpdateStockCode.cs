namespace Billbee.Net.Models
{
    public class UpdateStockCode
    {
        public string Sku { get; set; } = string.Empty;
        public long? StockId { get; set; }
        public string StockCode { get; set; } = string.Empty;
    }
}