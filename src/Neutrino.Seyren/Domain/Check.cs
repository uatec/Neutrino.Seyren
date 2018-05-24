using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using Newtonsoft.Json;

namespace Neutrino.Seyren.Domain
{
    public class Check
    {
        [DataMember(Name = "id")]
        public String Id  { get; set; }

        [DataMember(Name = "name")]
        public String Name { get; set; }

        [DataMember(Name = "description")]
        public String Description { get; set; }

        [DataMember(Name = "target")]
        public String Target { get; set; }

        [DataMember(Name = "from")]
        public String From { get; set; }

        [DataMember(Name = "until")]
        public String Until { get; set; }

        [DataMember(Name = "warn")]
        public double Warn { get; set; } // TODO : Check against BigDecimal

        [DataMember(Name = "error")]
        public double Error { get; set; } // TODO : Check against BigDecimal

        [DataMember(Name = "enabled")]
        public bool Enabled { get; set; }

        [DataMember(Name = "live")]
        public bool Live { get; set; }

        [DataMember(Name = "allowNoData")]
        public bool AllowNoData { get; set; }

        [DataMember(Name = "state")]
        public AlertType State { get; set; }

        [DataMember(Name = "lastCheck")]
        [JsonConverter(typeof(SeyrenDateConverter))]
        public DateTime LastCheck { get; set; }

        [DataMember(Name = "subscriptions")]
        public List<Subscription> Subscriptions { get; set; } = new List<Subscription>();
    }
}
