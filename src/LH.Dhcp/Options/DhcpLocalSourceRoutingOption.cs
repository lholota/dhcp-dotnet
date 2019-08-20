using LH.Dhcp.Serialization.OptionSerialization;

namespace LH.Dhcp.Options
{
    [DhcpOption(DhcpOptionCode.SrcRteOnOff)]
    public class DhcpLocalSourceRoutingOption : IDhcpOption
    {
        public bool Enabled { get; }

        public DhcpLocalSourceRoutingOption(bool enabled)
        {
            Enabled = enabled;
        }
    }
}
