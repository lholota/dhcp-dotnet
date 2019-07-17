using System.Collections.Generic;
using System.Net;
using LH.Dhcp.Serialization.OptionSerialization;

namespace LH.Dhcp.Options
{
    [DhcpOption(DhcpOptionTypeCode.QuotesServer)]
    public class DhcpQuotesServerOption : IDhcpOption
    {
        public IReadOnlyList<IPAddress> QuotesServerAddresses { get; }

        public DhcpQuotesServerOption(IReadOnlyList<IPAddress> quotesServerAddresses)
        {
            QuotesServerAddresses = quotesServerAddresses;
        }
    }
}