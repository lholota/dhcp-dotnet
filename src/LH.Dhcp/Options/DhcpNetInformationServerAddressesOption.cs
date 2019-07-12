using System.Collections.Generic;
using System.Net;
using LH.Dhcp.Serialization.OptionSerialization;
using LH.Dhcp.Serialization.OptionSerialization.OptionValueSerialization;

namespace LH.Dhcp.Options
{
    [DhcpOption(DhcpOptionTypeCode.NISServers, typeof(DhcpIpAddressListOptionSerializer))]
    public class DhcpNetInformationServerAddressesOption : IDhcpOption
    {
        public DhcpNetInformationServerAddressesOption(IReadOnlyList<IPAddress> addresses)
        {
            Addresses = addresses;
        }

        public IReadOnlyList<IPAddress> Addresses { get; }
    }
}