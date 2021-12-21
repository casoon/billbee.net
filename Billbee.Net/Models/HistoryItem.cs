using System;
using System.Collections.Generic;
using Billbee.Net.Enums;

namespace Billbee.Net.Models
{
    public class HistoryItem
    {

        public DateTime Created { get; set; }

        public String EventTypeName { get; set; }

        public String Text { get; set; }

        public String EmployeeName { get; set; }

        public int TypeId { get; set; }

    }
}
