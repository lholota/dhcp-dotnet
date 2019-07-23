using System.Collections.Generic;
using System.Net;
using LH.Dhcp.Serialization.OptionSerialization;

namespace LH.Dhcp.Options
{
    [DhcpOption(DhcpOptionTypeCode.STDAServer)]
    public class DhcpStdaServersOption : IDhcpOption
    {
        public IReadOnlyList<IPAddress> StdaServerAddresses { get; }

        public DhcpStdaServersOption(IReadOnlyList<IPAddress> stdaServerAddresses)
        {
            StdaServerAddresses = stdaServerAddresses;
        }
    }
}