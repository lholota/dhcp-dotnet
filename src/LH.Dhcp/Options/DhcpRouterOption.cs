using System.Collections.Generic;
using System.Net;
using LH.Dhcp.Serialization.OptionSerialization;
using LH.Dhcp.Serialization.OptionSerialization.OptionValueSerialization;

namespace LH.Dhcp.Options
{
    [DhcpOption(DhcpOptionTypeCode.Router)]
    public class DhcpRouterOption : IDhcpOption
    {
        public DhcpRouterOption(IReadOnlyList<IPAddress> routerAddresses)
        {
            RouterAddresses = routerAddresses;
        }

        public IReadOnlyList<IPAddress> RouterAddresses { get; }
    }
}