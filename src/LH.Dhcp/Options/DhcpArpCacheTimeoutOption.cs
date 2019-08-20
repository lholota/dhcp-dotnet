using System;
using LH.Dhcp.Serialization.OptionSerialization;

namespace LH.Dhcp.Options
{
    [DhcpOption(DhcpOptionCode.ARPTimeout)]
    public class DhcpArpCacheTimeoutOption : IDhcpOption
    {
        [CreateOptionConstructor]
        internal DhcpArpCacheTimeoutOption(uint timeoutSeconds)
        {
            Timeout = TimeSpan.FromSeconds(timeoutSeconds);
        }

        public DhcpArpCacheTimeoutOption(TimeSpan timeout)
        {
            Timeout = timeout;
        }

        public TimeSpan Timeout { get; }
    }
}