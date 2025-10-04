namespace Billbee.Net.Models
{
    public class ShippingProduct
    {
        /// <summary>
        ///     Id of this shipping product
        /// </summary>
        public long id { get; set; }

        /// <summary>
        ///     Human readable name of this shippingproduct
        /// </summary>
        public string displayName { get; set; } = string.Empty;

        /// <summary>
        ///     Provider specific product name
        /// </summary>
        public string productName { get; set; } = string.Empty;
    }
}