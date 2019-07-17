using System.Collections.Generic;
using System.Net;
using LH.Dhcp.Serialization.OptionSerialization;

namespace LH.Dhcp.Options
{
    [DhcpOption(DhcpOptionTypeCode.RLPServer)]
    public class DhcpResourceLocationServerOption : IDhcpOption
    {
        public DhcpResourceLocationServerOption(IReadOnlyList<IPAddress> rlpServerAddresses)
        {
            RlpServerAddresses = rlpServerAddresses;
        }

        public IReadOnlyList<IPAddress> RlpServerAddresses { get; }
    }
}