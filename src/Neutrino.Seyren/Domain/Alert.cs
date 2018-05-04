using System;
using System.Runtime.Serialization;

namespace Neutrino.Seyren.Domain
{
    public class Alert
    {
        [DataMember(Name = "id")]
        public String Id { get; set; }
        
        [DataMember(Name = "checkId")]
        public String CheckId { get; set; }
        
        [DataMember(Name = "value")]
        public double Value { get; set; } // TODO: Convert to BigDecimal
        
        [DataMember(Name = "target")]
        public String Target { get; set; }
        
        [DataMember(Name = "warn")]
        public double Warn { get; set; } // TODO: Convert to BigDecimal
        
        [DataMember(Name = "error")]
        public double Error { get; set; } // TODO: Convert to BigDecimal
        
        [DataMember(Name = "fromType")]
        public AlertType FromType { get; set; }
        
        [DataMember(Name = "toType")]
        public AlertType ToType { get; set; }
        
        [DataMember(Name = "timestamp")]
        public DateTime Timestamp { get; set; }
    }
}
