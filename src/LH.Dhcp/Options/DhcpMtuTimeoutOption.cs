using LH.Dhcp.Serialization.OptionSerialization;
using LH.Dhcp.Serialization.OptionSerialization.OptionValueSerialization;

namespace LH.Dhcp.Options
{
    [DhcpOption(DhcpOptionTypeCode.MTUTimeout, typeof(DhcpUnsignedInt32OptionSerializer))]
    public class DhcpMtuTimeoutOption : IDhcpOption
    {
        public uint MtuTimeout { get; }

        public DhcpMtuTimeoutOption(uint mtuTimeout)
        {
            MtuTimeout = mtuTimeout;
        }
    }
}
