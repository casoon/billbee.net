﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Billbee.Net.Models
{
    public class CustomerSearchResult
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public string Addresses { get; set; }
        public string Number { get; set; }
    }
}
