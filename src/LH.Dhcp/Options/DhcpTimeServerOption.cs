using System.Collections.Generic;
using System.Net;
using LH.Dhcp.Serialization.OptionSerialization;

namespace LH.Dhcp.Options
{
    [DhcpOption(DhcpOptionTypeCode.TimeServer)]
    public class DhcpTimeServerOption : IDhcpOption
    {
        public DhcpTimeServerOption(IEnumerable<IPAddress> timeServerAddresses)
        {
            TimeServerAddresses = timeServerAddresses;
        }

        public IEnumerable<IPAddress> TimeServerAddresses { get; }
    }
}