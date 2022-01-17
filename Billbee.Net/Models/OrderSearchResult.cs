namespace Billbee.Net.Models
{
    public class OrderSearchResult
    {
        public long Id { get; set; }
        public string ExternalReference { get; set; }
        public string BuyerName { get; set; }
        public string InvoiceNumber { get; set; }
        public string CustomerName { get; set; }
        public string ArticleTexts { get; set; }
    }
}