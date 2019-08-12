using System.Net;
using LH.Dhcp.Serialization.OptionSerialization;

namespace LH.Dhcp.Options
{
    [DhcpOption(DhcpOptionTypeCode.AddressRequest)]
    public class DhcpRequestedAddressOption : IDhcpOption
    {
        public DhcpRequestedAddressOption(IPAddress requestedAddress)
        {
            RequestedAddress = requestedAddress;
        }

        public IPAddress RequestedAddress { get; }
    }
}