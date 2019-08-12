using System.Collections.Generic;
using System.Net;
using LH.Dhcp.Serialization.OptionSerialization;

namespace LH.Dhcp.Options
{
    [DhcpOption(DhcpOptionTypeCode.NETBIOSNameSrv)]
    public class DhcpNetBiosNameServersOption : IDhcpOption
    {
        public DhcpNetBiosNameServersOption(IReadOnlyList<IPAddress> nameServers)
        {
            NameServers = nameServers;
        }

        public IReadOnlyList<IPAddress> NameServers { get; }
    }
}