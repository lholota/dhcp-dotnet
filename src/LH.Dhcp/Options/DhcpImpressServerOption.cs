using System.Collections.Generic;
using System.Net;
using LH.Dhcp.Serialization.OptionSerialization;

namespace LH.Dhcp.Options
{
    [DhcpOption(DhcpOptionTypeCode.ImpressServer)]
    public class DhcpImpressServerOption : IDhcpOption
    {
        public DhcpImpressServerOption(IEnumerable<IPAddress> impressServerAddresses)
        {
            ImpressServerAddresses = impressServerAddresses;
        }

        public IEnumerable<IPAddress> ImpressServerAddresses { get; }
    }
}
