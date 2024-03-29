﻿namespace Billbee.Net.Models
{
    public class OrderUser
    {
        public string Platform { get; set; }
        public string BillbeeShopName { get; set; }
        public long? BillbeeShopId { get; set; }
        public string Id { get; set; }
        public string Nick { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }

        public string FullName => string.Format("{0} {1}", FirstName, LastName).Trim();

        public string Email { get; set; }
    }
}