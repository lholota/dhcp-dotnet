using System.Collections.Generic;
using System.Net;
using LH.Dhcp.Serialization.OptionSerialization;
using LH.Dhcp.Serialization.OptionSerialization.OptionValueSerialization;

namespace LH.Dhcp.Options
{
    [DhcpOption(DhcpOptionTypeCode.RLPServer, typeof(DhcpIpAddressListOptionSerializer))]
    public class DhcpResourceLocationServerOption : IDhcpOption
    {
        public DhcpResourceLocationServerOption(IEnumerable<IPAddress> rlpServerAddresses)
        {
            RlpServerAddresses = rlpServerAddresses;
        }

        public IEnumerable<IPAddress> RlpServerAddresses { get; }
    }
}