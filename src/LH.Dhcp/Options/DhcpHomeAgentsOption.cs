using System.Collections.Generic;
using System.Net;
using LH.Dhcp.Serialization.OptionSerialization;

namespace LH.Dhcp.Options
{
    [DhcpOption(DhcpOptionTypeCode.HomeAgentAddrs)]
    public class DhcpHomeAgentsOption : IDhcpOption
    {
        public IReadOnlyList<IPAddress> HomeAgentAddresses { get; }

        public DhcpHomeAgentsOption(IReadOnlyList<IPAddress> homeAgentAddresses)
        {
            HomeAgentAddresses = homeAgentAddresses;
        }
    }
}