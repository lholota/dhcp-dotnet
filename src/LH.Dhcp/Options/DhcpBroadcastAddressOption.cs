using System.Net;
using LH.Dhcp.Serialization.OptionSerialization;
using LH.Dhcp.Serialization.OptionSerialization.OptionValueSerialization;

namespace LH.Dhcp.Options
{
    [DhcpOption(DhcpOptionTypeCode.BroadcastAddress, typeof(DhcpIpAddressOptionSerializer))]
    public class DhcpBroadcastAddressOption : IDhcpOption
    {
        public DhcpBroadcastAddressOption(IPAddress broadcastAddress)
        {
            BroadcastAddress = broadcastAddress;
        }

        public IPAddress BroadcastAddress { get; }
    }
}