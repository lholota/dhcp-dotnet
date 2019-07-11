using System.Collections.Generic;
using System.Net;
using LH.Dhcp.Serialization.OptionSerialization;
using LH.Dhcp.Serialization.OptionSerialization.OptionValueSerialization;

namespace LH.Dhcp.Options
{
    [DhcpOption(DhcpOptionTypeCode.LogServer, typeof(DhcpIpAddressListOptionSerializer))]
    public class DhcpLogServerOption : IDhcpOption
    {
        public IEnumerable<IPAddress> LogServerAddresses { get; }

        public DhcpLogServerOption(IEnumerable<IPAddress> logServerAddresses)
        {
            LogServerAddresses = logServerAddresses;
        }
    }
}