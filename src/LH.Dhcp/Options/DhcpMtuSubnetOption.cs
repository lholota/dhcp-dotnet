using LH.Dhcp.Serialization.OptionSerialization;
using LH.Dhcp.Serialization.OptionSerialization.OptionValueSerialization;

namespace LH.Dhcp.Options
{
    [DhcpOption(DhcpOptionTypeCode.MTUSubnet, typeof(DhcpBooleanOptionSerializer))]
    public class DhcpMtuSubnetOption : IDhcpOption
    {
        public bool AllSubnetsLocal { get; }

        public DhcpMtuSubnetOption(bool allSubnetsLocal)
        {
            AllSubnetsLocal = allSubnetsLocal;
        }
    }
}