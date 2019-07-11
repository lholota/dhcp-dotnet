using System.Net;
using LH.Dhcp.Serialization.OptionSerialization;
using LH.Dhcp.Serialization.OptionSerialization.OptionValueSerialization;

namespace LH.Dhcp.Options
{
    [DhcpOption(DhcpOptionTypeCode.SwapServer, typeof(DhcpIpAddressOptionSerializer))]
    public class DhcpSwapServerOption : IDhcpOption
    {
        public DhcpSwapServerOption(IPAddress swapServerAddress)
        {
            SwapServerAddress = swapServerAddress;
        }

        public IPAddress SwapServerAddress { get; }
    }
}