using System.Collections.Generic;
using System.Net;
using LH.Dhcp.Serialization.OptionSerialization;

namespace LH.Dhcp.Options
{
    [DhcpOption(DhcpOptionCode.DomainNameServer)]
    public class DhcpDomainNameServerOption : IDhcpOption
    {
        public DhcpDomainNameServerOption(IReadOnlyList<IPAddress> dnsServerAddresses)
        {
            DnsServerAddresses = dnsServerAddresses;
        }

        public IReadOnlyList<IPAddress> DnsServerAddresses { get; }
    }
}