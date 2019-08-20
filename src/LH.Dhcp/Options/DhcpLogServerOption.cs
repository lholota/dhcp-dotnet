using System.Collections.Generic;
using System.Net;
using LH.Dhcp.Serialization.OptionSerialization;

namespace LH.Dhcp.Options
{
    [DhcpOption(DhcpOptionCode.LogServer)]
    public class DhcpLogServerOption : IDhcpOption
    {
        public IReadOnlyList<IPAddress> LogServerAddresses { get; }

        public DhcpLogServerOption(IReadOnlyList<IPAddress> logServerAddresses)
        {
            LogServerAddresses = logServerAddresses;
        }
    }
}