namespace Billbee.Net.Models
{
    public class TriggerEventContainer
    {
        /// <summary>Name of the event</summary>
        public string Name { get; set; }

        /// <summary>The delay in minutes until the rule is executed</summary>
        public uint DelayInMinutes { get; set; } = 0;
    }
}