using System;
using System.Collections.Generic;
using Billbee.Net.Enums;

namespace Billbee.Net.Models
{
    public class Payment
    {
        /// <summary>
        /// Internal Id of billbee
        /// </summary>
        public long? BillbeeId { get; set; }

        public string TransactionId { get; set; }

        public DateTime PayDate { get; set; }

        public PaymentTypeEnum? PaymentType { get; set; }

        public string SourceTechnology { get; set; }

        public string SourceText { get; set; }

        public decimal PayValue { get; set; }

        public string Purpose { get; set; }

        public string Name { get; set; }

    }
}
