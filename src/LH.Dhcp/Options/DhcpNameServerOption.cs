using System.Collections.Generic;
using System.Net;
using LH.Dhcp.Serialization.OptionSerialization;

namespace LH.Dhcp.Options
{
    [DhcpOption(DhcpOptionCode.NameServer)]
    public class DhcpNameServerOption : IDhcpOption
    {
        public IReadOnlyList<IPAddress> NameServerAddresses { get; }

        public DhcpNameServerOption(IReadOnlyList<IPAddress> nameServerAddresses)
        {
            NameServerAddresses = nameServerAddresses;
        }
    }
}