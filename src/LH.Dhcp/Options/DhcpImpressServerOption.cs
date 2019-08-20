using System.Collections.Generic;
using System.Net;
using LH.Dhcp.Serialization.OptionSerialization;

namespace LH.Dhcp.Options
{
    [DhcpOption(DhcpOptionCode.ImpressServer)]
    public class DhcpImpressServerOption : IDhcpOption
    {
        public DhcpImpressServerOption(IReadOnlyList<IPAddress> impressServerAddresses)
        {
            ImpressServerAddresses = impressServerAddresses;
        }

        public IReadOnlyList<IPAddress> ImpressServerAddresses { get; }
    }
}
