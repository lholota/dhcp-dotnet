using LH.Dhcp.Serialization.OptionSerialization;

namespace LH.Dhcp.Options
{
    [DhcpOption(DhcpOptionTypeCode.MTUTimeout)]
    public class DhcpMtuTimeoutOption : IDhcpOption
    {
        public DhcpMtuTimeoutOption(uint mtuTimeout)
        {
            MtuTimeout = mtuTimeout;
        }

        // TODO: Timespan
        public uint MtuTimeout { get; }
    }
}
