using System.Collections.Generic;
using System.Net;
using LH.Dhcp.Serialization.OptionSerialization;

namespace LH.Dhcp.Options
{
    [DhcpOption(DhcpOptionTypeCode.WWWServer)]
    public class DhcpWwwServersOption : IDhcpOption
    {
        public IReadOnlyList<IPAddress> WwwServerAddresses { get; }

        public DhcpWwwServersOption(IReadOnlyList<IPAddress> wwwServerAddresses)
        {
            WwwServerAddresses = wwwServerAddresses;
        }
    }
}
