using System.Collections.Generic;
using System.Net;
using LH.Dhcp.Serialization.OptionSerialization;

namespace LH.Dhcp.Options
{
    [DhcpOption(DhcpOptionCode.NETBIOSDistSrv)]
    public class DhcpNetBiosDistributionServersOption : IDhcpOption
    {
        public DhcpNetBiosDistributionServersOption(IReadOnlyList<IPAddress> distributionServers)
        {
            DistributionServers = distributionServers;
        }

        public IReadOnlyList<IPAddress> DistributionServers { get; }
    }
}