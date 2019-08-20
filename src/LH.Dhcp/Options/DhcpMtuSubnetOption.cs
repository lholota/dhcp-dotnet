using LH.Dhcp.Serialization.OptionSerialization;

namespace LH.Dhcp.Options
{
    [DhcpOption(DhcpOptionCode.MTUSubnet)]
    public class DhcpMtuSubnetOption : IDhcpOption
    {
        public DhcpMtuSubnetOption(bool allSubnetsLocal)
        {
            AllSubnetsLocal = allSubnetsLocal;
        }

        public bool AllSubnetsLocal { get; }
    }
}