using System.Runtime.Serialization;

namespace Neutrino.Seyren.Domain
{
    public enum AlertType
    {
        [EnumMember(Value = "UNKNOWN")]
        Unknown = 0,

        [EnumMember(Value = "OK")]
        Ok = 1,

        [EnumMember(Value = "WARN")]
        Warn = 2,

        [EnumMember(Value = "ERROR")]
        Error = 3,

        [EnumMember(Value = "EXCEPTION")]
        Exception = 4
    }
}
