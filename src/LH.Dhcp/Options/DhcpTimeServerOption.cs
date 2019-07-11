using System.Collections.Generic;
using System.Net;
using LH.Dhcp.Serialization.OptionSerialization;
using LH.Dhcp.Serialization.OptionSerialization.OptionValueSerialization;

namespace LH.Dhcp.Options
{
    [DhcpOption(DhcpOptionTypeCode.TimeServer, typeof(DhcpIpAddressListOptionSerializer))]
    public class DhcpTimeServerOption : IDhcpOption
    {
        public DhcpTimeServerOption(IEnumerable<IPAddress> timeServerAddresses)
        {
            TimeServerAddresses = timeServerAddresses;
        }

        public IEnumerable<IPAddress> TimeServerAddresses { get; }
    }
}