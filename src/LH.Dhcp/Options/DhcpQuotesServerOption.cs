using System.Collections.Generic;
using System.Net;
using LH.Dhcp.Serialization.OptionSerialization;
using LH.Dhcp.Serialization.OptionSerialization.OptionValueSerialization;

namespace LH.Dhcp.Options
{
    [DhcpOption(DhcpOptionTypeCode.QuotesServer, typeof(DhcpIpAddressListOptionSerializer))]
    public class DhcpQuotesServerOption : IDhcpOption
    {
        public IEnumerable<IPAddress> QuotesServerAddresses { get; }

        public DhcpQuotesServerOption(IEnumerable<IPAddress> quotesServerAddresses)
        {
            QuotesServerAddresses = quotesServerAddresses;
        }
    }
}