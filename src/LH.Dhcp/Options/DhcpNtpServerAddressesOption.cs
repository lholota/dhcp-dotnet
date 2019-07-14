using System.Collections.Generic;
using System.Net;
using LH.Dhcp.Serialization.OptionSerialization;

namespace LH.Dhcp.Options
{
    [DhcpOption(DhcpOptionTypeCode.NTPServers)]
    public class DhcpNtpServerAddressesOption : IDhcpOption
    {
        public DhcpNtpServerAddressesOption(IReadOnlyList<IPAddress> addresses)
        {
            Addresses = addresses;
        }

        public IReadOnlyList<IPAddress> Addresses { get; }
    }
}