using System.Net;
using LH.Dhcp.Serialization.OptionSerialization;

namespace LH.Dhcp.Options
{
    [DhcpOption(DhcpOptionTypeCode.BroadcastAddress)]
    public class DhcpBroadcastAddressOption : IDhcpOption
    {
        public DhcpBroadcastAddressOption(IPAddress broadcastAddress)
        {
            BroadcastAddress = broadcastAddress;
        }

        public IPAddress BroadcastAddress { get; }
    }
}