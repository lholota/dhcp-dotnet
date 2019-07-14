using System;
using LH.Dhcp.Serialization.OptionSerialization;

namespace LH.Dhcp.Options
{
    [DhcpOption(DhcpOptionTypeCode.ARPTimeout)]
    public class DhcpArpCacheTimeoutOption : IDhcpOption
    {
        public DhcpArpCacheTimeoutOption(TimeSpan timeout)
        {
            Timeout = timeout;
        }

        public TimeSpan Timeout { get; }
    }
}