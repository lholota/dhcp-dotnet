using System.Collections.Generic;
using System.Net;
using LH.Dhcp.Serialization.OptionSerialization;

namespace LH.Dhcp.Options
{
    [DhcpOption(DhcpOptionTypeCode.NISPlusServerAddr)]
    public class DhcpNetInformationPlusServersOption : IDhcpOption
    {
        public IReadOnlyList<IPAddress> ServerAddresses { get; }

        public DhcpNetInformationPlusServersOption(IReadOnlyList<IPAddress> serverAddresses)
        {
            ServerAddresses = serverAddresses;
        }
    }
}