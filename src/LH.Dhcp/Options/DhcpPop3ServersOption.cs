using System.Collections.Generic;
using System.Net;
using LH.Dhcp.Serialization.OptionSerialization;

namespace LH.Dhcp.Options
{
    [DhcpOption(DhcpOptionTypeCode.POP3Server)]
    public class DhcpPop3ServersOption : IDhcpOption
    {
        public IReadOnlyList<IPAddress> Pop3ServerAddresses { get; }

        public DhcpPop3ServersOption(IReadOnlyList<IPAddress> pop3ServerAddresses)
        {
            Pop3ServerAddresses = pop3ServerAddresses;
        }
    }
}