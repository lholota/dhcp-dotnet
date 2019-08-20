using System.Collections.Generic;
using LH.Dhcp.Serialization.OptionSerialization;

namespace LH.Dhcp.Options
{
    [DhcpOption(DhcpOptionCode.ParameterList)]
    public class DhcpParameterRequestListOption : IDhcpOption
    {
        public DhcpParameterRequestListOption(byte[] requestedOptions)
        {
            RequestedOptions = requestedOptions;
        }

        public IReadOnlyList<byte> RequestedOptions { get; }
    }
}