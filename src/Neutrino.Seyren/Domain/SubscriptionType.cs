using System.Runtime.Serialization;

namespace Neutrino.Seyren.Domain
{
    public enum SubscriptionType
    {
        [EnumMember(Value = "EMAIL")]
        Email,
    
        [EnumMember(Value = "PAGERDUTY")]
        PagerDuty,
    
        [EnumMember(Value = "HIPCHAT")]
        Hipchat,
    
        [EnumMember(Value = "HUBOT")]
        Hubot,
    
        [EnumMember(Value = "FLOWDOCK")]
        FlowDock,
    
        [EnumMember(Value = "HTTP")]
        Http,
    
        [EnumMember(Value = "IRCCAT")]
        IRCCat,
    
        [EnumMember(Value = "PUSHOVER")]
        PushOver,
    
        [EnumMember(Value = "LOGGER")]
        Logger,
    
        [EnumMember(Value = "SNMP")]
        SNMP,
    
        [EnumMember(Value = "SLACK")]
        Slack,
    
        [EnumMember(Value = "TWILIO")]
        Twilio,
    
        [EnumMember(Value = "VICTOROPS")]
        VictorOps,
    
        [EnumMember(Value = "OPSGENIE")]
        OpsGenie,
     
        [EnumMember(Value = "BIGPANDA")]
        BigPanda
    }
}
