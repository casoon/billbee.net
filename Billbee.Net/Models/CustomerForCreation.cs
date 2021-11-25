using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Billbee.Net.Models
{
    public class CustomerForCreation : Customer
    {
        public CustomerAddress Address { get; set; }
    }
}
