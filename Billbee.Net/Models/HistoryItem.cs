using System;

namespace Billbee.Net.Models
{
    public class HistoryItem
    {
        public DateTime Created { get; set; }

        public string EventTypeName { get; set; }

        public string Text { get; set; }

        public string EmployeeName { get; set; }

        public int TypeId { get; set; }
    }
}