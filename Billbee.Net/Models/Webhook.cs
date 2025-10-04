using System.Collections.Generic;

namespace Billbee.Net.Models
{
    public class Webhook
    {
        public string Id { get; set; } = string.Empty;
        public string WebHookUri { get; set; } = string.Empty;
        public string Secret { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public bool IsPaused { get; set; }
        public List<string> Filters { get; set; } = new();
        public Dictionary<string, string> Headers { get; set; } = new();
        public Dictionary<string, object> Properties { get; set; } = new();
    }
}