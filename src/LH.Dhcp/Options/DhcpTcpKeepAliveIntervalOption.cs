using System;
using LH.Dhcp.Serialization.OptionSerialization;

namespace LH.Dhcp.Options
{
    [DhcpOption(DhcpOptionTypeCode.KeepaliveTime)]
    public class DhcpTcpKeepAliveIntervalOption : IDhcpOption
    {
        [CreateOptionConstructor]
        internal DhcpTcpKeepAliveIntervalOption(uint seconds)
        {
            Interval = TimeSpan.FromSeconds(seconds);
        }

        public DhcpTcpKeepAliveIntervalOption(TimeSpan interval)
        {
            Interval = interval;
        }

        public TimeSpan Interval { get; }
    }
}