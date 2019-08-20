using System.Collections.Generic;
using System.Net;
using LH.Dhcp.Serialization.OptionSerialization;

namespace LH.Dhcp.Options
{
    [DhcpOption(DhcpOptionCode.TimeServer)]
    public class DhcpTimeServerOption : IDhcpOption
    {
        public DhcpTimeServerOption(IReadOnlyList<IPAddress> timeServerAddresses)
        {
            TimeServerAddresses = timeServerAddresses;
        }

        public IEnumerable<IPAddress> TimeServerAddresses { get; }
    }
}