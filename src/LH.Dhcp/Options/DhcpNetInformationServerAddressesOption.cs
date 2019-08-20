using System.Collections.Generic;
using System.Net;
using LH.Dhcp.Serialization.OptionSerialization;

namespace LH.Dhcp.Options
{
    [DhcpOption(DhcpOptionCode.NISServers)]
    public class DhcpNetInformationServerAddressesOption : IDhcpOption
    {
        public DhcpNetInformationServerAddressesOption(IReadOnlyList<IPAddress> addresses)
        {
            Addresses = addresses;
        }

        public IReadOnlyList<IPAddress> Addresses { get; }
    }
}