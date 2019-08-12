using System.Collections.Generic;
using System.Net;
using LH.Dhcp.Serialization.OptionSerialization;

namespace LH.Dhcp.Options
{
    [DhcpOption(DhcpOptionTypeCode.XWindowManager)]
    public class DhcpXWindowManagerServersOption : IDhcpOption
    {
        public DhcpXWindowManagerServersOption(IReadOnlyList<IPAddress> managerServers)
        {
            ManagerServers = managerServers;
        }

        public IReadOnlyList<IPAddress> ManagerServers { get; }
    }
}