using LH.Dhcp.Serialization.OptionSerialization;

namespace LH.Dhcp.Options
{
    [DhcpOption(DhcpOptionTypeCode.SrcRteOnOff)]
    public class DhcpLocalSourceRoutingOption : IDhcpOption
    {
        public bool Enabled { get; }

        public DhcpLocalSourceRoutingOption(bool enabled)
        {
            Enabled = enabled;
        }
    }
}
