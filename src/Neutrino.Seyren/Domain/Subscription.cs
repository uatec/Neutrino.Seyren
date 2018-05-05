using System;
using System.Runtime.Serialization;

namespace Neutrino.Seyren.Domain
{
    public class Subscription
    {
        [DataMember(Name = "id")]
        public String Id { get; set; }

        [DataMember(Name = "target")]
        public String Target { get; set; }

        [DataMember(Name = "type")]
        public SubscriptionType Type { get; set; }

        [DataMember(Name = "su")]
        public bool EnabledOnSunday { get; set; }

        [DataMember(Name = "mo")]
        public bool EnabledOnMonday { get; set; }

        [DataMember(Name = "tu")]
        public bool EnabledOnTuesday { get; set; }

        [DataMember(Name = "we")]
        public bool EnabledOnWednesday { get; set; }

        [DataMember(Name = "th")]
        public bool EnabledOnThursday { get; set; }

        [DataMember(Name = "fr")]
        public bool EnabledOnFriday { get; set; }

        [DataMember(Name = "sa")]
        public bool EnabledOnSaturday { get; set; }

        [DataMember(Name = "ignoreWarn")]
        public bool IgnoreWarn { get; set; }

        [DataMember(Name = "ignoreError")]
        public bool IgnoreError { get; set; }

        [DataMember(Name = "ignoreOk")]
        public bool IgnoreOk { get; set; }

        [DataMember(Name = "fromTime")]
        public string FromTime { get; set; } 

        [DataMember(Name = "toTime")]
        public string ToTime { get; set; }

        [DataMember(Name = "enabled")]
        public bool Enabled { get; set; }
    }
}
