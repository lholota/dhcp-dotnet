using System.Collections.Generic;
using System.Net;
using LH.Dhcp.Serialization.OptionSerialization;
using LH.Dhcp.Serialization.OptionSerialization.OptionValueSerialization;

namespace LH.Dhcp.Options
{
    [DhcpOption(DhcpOptionTypeCode.NTPServers, typeof(DhcpIpAddressListOptionSerializer))]
    public class DhcpNtpServerAddressesOption : IDhcpOption
    {
        public DhcpNtpServerAddressesOption(IReadOnlyList<IPAddress> addresses)
        {
            Addresses = addresses;
        }

        public IReadOnlyList<IPAddress> Addresses { get; }
    }
}