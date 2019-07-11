using System.Collections.Generic;
using System.Net;
using LH.Dhcp.Serialization.OptionSerialization;
using LH.Dhcp.Serialization.OptionSerialization.OptionValueSerialization;

namespace LH.Dhcp.Options
{
    [DhcpOption(DhcpOptionTypeCode.DomainNameServer, typeof(DhcpIpAddressListOptionSerializer))]
    public class DhcpDomainNameServerOption : IDhcpOption
    {
        public IEnumerable<IPAddress> DnsServerAddresses { get; }

        public DhcpDomainNameServerOption(IEnumerable<IPAddress> dnsServerAddresses)
        {
            DnsServerAddresses = dnsServerAddresses;
        }
    }
}