using System.Collections.Generic;
using System.Net;
using LH.Dhcp.Serialization.OptionSerialization;
using LH.Dhcp.Serialization.OptionSerialization.OptionValueSerialization;

namespace LH.Dhcp.Options
{
    [DhcpOption(DhcpOptionTypeCode.ImpressServer, typeof(DhcpIpAddressListOptionSerializer))]
    public class DhcpImpressServerOption : IDhcpOption
    {
        public DhcpImpressServerOption(IEnumerable<IPAddress> impressServerAddresses)
        {
            ImpressServerAddresses = impressServerAddresses;
        }

        public IEnumerable<IPAddress> ImpressServerAddresses { get; }
    }
}
