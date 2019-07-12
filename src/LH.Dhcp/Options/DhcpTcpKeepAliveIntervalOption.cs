using System;
using LH.Dhcp.Serialization.OptionSerialization;
using LH.Dhcp.Serialization.OptionSerialization.OptionValueSerialization;

namespace LH.Dhcp.Options
{
    [DhcpOption(DhcpOptionTypeCode.KeepaliveTime, typeof(DhcpUnsignedInt32OptionSerializer))]
    public class DhcpTcpKeepAliveIntervalOption : IDhcpOption
    {
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