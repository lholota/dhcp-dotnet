using System.Collections.Generic;
using System.Net;
using LH.Dhcp.Serialization.OptionSerialization;

namespace LH.Dhcp.Options
{
    [DhcpOption(DhcpOptionTypeCode.XWindowFont)]
    public class DhcpXWindowFontServersOption : IDhcpOption
    {
        public DhcpXWindowFontServersOption(IReadOnlyList<IPAddress> fontServers)
        {
            FontServers = fontServers;
        }

        public IReadOnlyList<IPAddress> FontServers { get; }
    }
}