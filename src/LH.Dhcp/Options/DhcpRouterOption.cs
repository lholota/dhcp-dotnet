using System.Collections.Generic;
using System.Net;
using LH.Dhcp.Serialization.OptionSerialization;
using LH.Dhcp.Serialization.OptionSerialization.OptionValueSerialization;

namespace LH.Dhcp.Options
{
    [DhcpOption(DhcpOptionTypeCode.Router, typeof(DhcpIpAddressListOptionSerializer))]
    public class DhcpRouterOption : IDhcpOption
    {
        public DhcpRouterOption(IEnumerable<IPAddress> routerAddresses)
        {
            RouterAddresses = routerAddresses;
        }

        public IEnumerable<IPAddress> RouterAddresses { get; }
    }
}