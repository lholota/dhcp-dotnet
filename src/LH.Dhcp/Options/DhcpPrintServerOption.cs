using System.Collections.Generic;
using System.Net;
using LH.Dhcp.Serialization.OptionSerialization;

namespace LH.Dhcp.Options
{
    [DhcpOption(DhcpOptionCode.LPRServer)]
    public class DhcpPrintServerOption : IDhcpOption
    {
        public DhcpPrintServerOption(IReadOnlyList<IPAddress> printServerAddresses)
        {
            PrintServerAddresses = printServerAddresses;
        }

        public IReadOnlyList<IPAddress> PrintServerAddresses { get; }
    }
}
