using System.Runtime.Serialization;

namespace Neutrino.Seyren.Domain
{
    public class SeyrenResponse<T>
    {
        [DataMember(Name = "values")]
        public T[] Values { get; set; }

        [DataMember(Name = "items")]
        public int Items { get; set; }

        [DataMember(Name = "start")]
        public int Start { get; set; }

        [DataMember(Name = "total")]
        public int Total { get; set; }
    }
}
