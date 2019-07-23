using System.Collections.Generic;
using System.Net;
using LH.Dhcp.Serialization.OptionSerialization;

namespace LH.Dhcp.Options
{
    [DhcpOption(DhcpOptionTypeCode.StreetTalkServer)]
    public class DhcpStreetTalkServersOption : IDhcpOption
    {
        public IReadOnlyList<IPAddress> StreetTalkServerAddresses { get; }

        public DhcpStreetTalkServersOption(IReadOnlyList<IPAddress> streetTalkServerAddresses)
        {
            StreetTalkServerAddresses = streetTalkServerAddresses;
        }
    }
}
