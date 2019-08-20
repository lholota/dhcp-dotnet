using System;
using LH.Dhcp.Serialization.OptionSerialization;

namespace LH.Dhcp.Options
{
    [DhcpOption(DhcpOptionCode.MTUTimeout)]
    public class DhcpMtuTimeoutOption : IDhcpOption
    {
        [CreateOptionConstructor]
        internal DhcpMtuTimeoutOption(uint mtuTimeout)
        {
            MtuTimeout = TimeSpan.FromSeconds(mtuTimeout);
        }

        public DhcpMtuTimeoutOption(TimeSpan mtuTimeout)
        {
            MtuTimeout = mtuTimeout;
        }

        // TODO: Timespan
        public TimeSpan MtuTimeout { get; }
    }
}
