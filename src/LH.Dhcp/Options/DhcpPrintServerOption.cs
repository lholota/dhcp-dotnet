using System.Collections.Generic;
using System.Net;
using LH.Dhcp.Serialization.OptionSerialization;
using LH.Dhcp.Serialization.OptionSerialization.OptionValueSerialization;

namespace LH.Dhcp.Options
{
    [DhcpOption(DhcpOptionTypeCode.LPRServer, typeof(DhcpIpAddressListOptionSerializer))]
    public class DhcpPrintServerOption : IDhcpOption
    {
        public DhcpPrintServerOption(IEnumerable<IPAddress> printServerAddresses)
        {
            PrintServerAddresses = printServerAddresses;
        }

        public IEnumerable<IPAddress> PrintServerAddresses { get; }
    }
}
