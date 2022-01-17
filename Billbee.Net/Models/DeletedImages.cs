using System.Collections.Generic;

namespace Billbee.Net.Models
{
    public class DeletedImages
    {
        public List<int> Deleted { get; set; }
        public List<int> NotFound { get; set; }
    }
}