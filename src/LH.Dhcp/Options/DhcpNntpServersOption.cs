using System.Collections.Generic;
using System.Net;
using LH.Dhcp.Serialization.OptionSerialization;

namespace LH.Dhcp.Options
{
    [DhcpOption(DhcpOptionTypeCode.NNTPServer)]
    public class DhcpNntpServersOption : IDhcpOption
    {
        public IReadOnlyList<IPAddress> NntpServerAddresses { get; }

        public DhcpNntpServersOption(IReadOnlyList<IPAddress> nntpServerAddresses)
        {
            NntpServerAddresses = nntpServerAddresses;
        }
    }
}