﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Billbee.Net.Models
{
    public class DeletedImages
    {
        public List<int> Deleted { get; set; }
        public List<int> NotFound { get; set; }
    }
}
