using System.Runtime.Serialization;

namespace Neutrino.Seyren
{
    public class SeyrenConfig
    {
        [DataMember(Name = "baseUrl")]
        public string BaseUrl { get; set; }

        [DataMember(Name = "graphsEnabled")]
        public bool GraphsEnabled { get; set; }

        [DataMember(Name = "graphiteCarbonPickleEnabled")]
        public bool GraphiteCarbonPickleEnabled { get; set; }
    }
}
