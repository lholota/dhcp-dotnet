using System.Net;
using LH.Dhcp.vNext.Internals;

namespace LH.Dhcp.vNext.Options
{
    [DhcpOptionCode(DhcpOptionCode.SubnetMask)]
    public class DhcpSubnetMaskOption : IDhcpOption
    {
        public DhcpSubnetMaskOption(IPAddress value)
        {
            SubnetMask = value;
            //CidrPrefix = value.ToCidrPrefix();
        }

        public IPAddress SubnetMask { get; }

        // TODO: public uint CidrPrefix { get; }
    }
}
