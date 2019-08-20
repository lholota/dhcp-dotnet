using System.Net;

namespace LH.Dhcp.vNext.Options
{
    [DhcpOption(DhcpOptionCode.SubnetMask)]
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
