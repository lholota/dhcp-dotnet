using System.Net;
using LH.Dhcp.Extensions;
using LH.Dhcp.Serialization.OptionSerialization;

namespace LH.Dhcp.Options
{
    [DhcpOption(DhcpOptionTypeCode.SubnetMask)]
    public class DhcpSubnetMaskOption : IDhcpOption
    {
        public DhcpSubnetMaskOption(IPAddress value)
        {
            SubnetMask = value;
            CidrPrefix = value.ToCidrPrefix();
        }

        public IPAddress SubnetMask { get; }

        public uint CidrPrefix { get; }
    }
}
