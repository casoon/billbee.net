namespace Billbee.Net.Models
{
    public class StockArticle
    {
        public string Name { get; set; } = string.Empty;
        public long StockId { get; set; }
        public decimal? StockCurrent { get; set; }
        public decimal? StockWarning { get; set; }
        public string StockCode { get; set; } = string.Empty;
        public decimal? UnfulfilledAmount { get; set; }
        public decimal? StockDesired { get; set; }
    }
}