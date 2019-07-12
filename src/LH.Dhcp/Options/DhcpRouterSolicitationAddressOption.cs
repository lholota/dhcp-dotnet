using System.Net;
using LH.Dhcp.Serialization.OptionSerialization;
using LH.Dhcp.Serialization.OptionSerialization.OptionValueSerialization;

namespace LH.Dhcp.Options
{
    [DhcpOption(DhcpOptionTypeCode.RouterRequest, typeof(DhcpIpAddressOptionSerializer))]
    public class DhcpRouterSolicitationAddressOption : IDhcpOption
    {
        public DhcpRouterSolicitationAddressOption(IPAddress routerSolicitationAddress)
        {
            RouterSolicitationAddress = routerSolicitationAddress;
        }

        public IPAddress RouterSolicitationAddress { get; }
    }
}