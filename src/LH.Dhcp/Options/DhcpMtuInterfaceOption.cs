using LH.Dhcp.Serialization.OptionSerialization;
using LH.Dhcp.Serialization.OptionSerialization.OptionValueSerialization;

namespace LH.Dhcp.Options
{
    [DhcpOption(DhcpOptionTypeCode.MTUInterface, typeof(DhcpUnsignedInt16OptionSerializer))]
    public class DhcpMtuInterfaceOption : IDhcpOption
    {
        public ushort Mtu { get; }

        public DhcpMtuInterfaceOption(ushort mtu)
        {
            Mtu = mtu;
        }
    }
}
