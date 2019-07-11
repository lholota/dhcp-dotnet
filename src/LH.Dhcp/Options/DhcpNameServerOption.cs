using System.Collections.Generic;
using System.Net;
using LH.Dhcp.Serialization.OptionSerialization;
using LH.Dhcp.Serialization.OptionSerialization.OptionValueSerialization;

namespace LH.Dhcp.Options
{
    [DhcpOption(DhcpOptionTypeCode.NameServer, typeof(DhcpIpAddressListOptionSerializer))]
    public class DhcpNameServerOption : IDhcpOption
    {
        public IEnumerable<IPAddress> NameServerAddresses { get; }

        public DhcpNameServerOption(IEnumerable<IPAddress> nameServerAddresses)
        {
            NameServerAddresses = nameServerAddresses;
        }
    }
}