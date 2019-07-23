using System.Collections.Generic;
using System.Net;
using LH.Dhcp.Serialization.OptionSerialization;

namespace LH.Dhcp.Options
{
    [DhcpOption(DhcpOptionTypeCode.FingerServer)]
    public class DhcpFingerServersOption : IDhcpOption
    {
        public IReadOnlyList<IPAddress> FingerServerAddresses { get; }

        public DhcpFingerServersOption(IReadOnlyList<IPAddress> fingerServerAddresses)
        {
            FingerServerAddresses = fingerServerAddresses;
        }
    }
}