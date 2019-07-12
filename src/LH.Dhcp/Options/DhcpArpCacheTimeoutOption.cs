using System;
using LH.Dhcp.Serialization.OptionSerialization;
using LH.Dhcp.Serialization.OptionSerialization.OptionValueSerialization;

namespace LH.Dhcp.Options
{
    [DhcpOption(DhcpOptionTypeCode.ARPTimeout, typeof(DhcpUnsignedInt32OptionSerializer))]
    public class DhcpArpCacheTimeoutOption : IDhcpOption
    {
        internal DhcpArpCacheTimeoutOption(uint seconds)
        {
            Timeout = TimeSpan.FromSeconds(seconds);
        }

        public DhcpArpCacheTimeoutOption(TimeSpan timeout)
        {
            Timeout = timeout;
        }

        public TimeSpan Timeout { get; }
    }
}