using LH.Dhcp.Serialization.OptionSerialization;
using LH.Dhcp.Serialization.OptionSerialization.OptionValueSerialization;

namespace LH.Dhcp.Options
{
    [DhcpOption(DhcpOptionTypeCode.SrcRteOnOff, typeof(DhcpBooleanOptionSerializer))]
    public class DhcpLocalSourceRoutingOption : IDhcpOption
    {
        public bool Enabled { get; }

        public DhcpLocalSourceRoutingOption(bool enabled)
        {
            Enabled = enabled;
        }
    }
}
