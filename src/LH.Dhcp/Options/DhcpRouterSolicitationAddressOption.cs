using System.Net;
using LH.Dhcp.Serialization.OptionSerialization;

namespace LH.Dhcp.Options
{
    [DhcpOption(DhcpOptionTypeCode.RouterRequest)]
    public class DhcpRouterSolicitationAddressOption : IDhcpOption
    {
        public DhcpRouterSolicitationAddressOption(IPAddress routerSolicitationAddress)
        {
            RouterSolicitationAddress = routerSolicitationAddress;
        }

        public IPAddress RouterSolicitationAddress { get; }
    }
}