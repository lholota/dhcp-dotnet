using System;
using LH.Dhcp.Serialization.OptionSerialization;

namespace LH.Dhcp.Options
{
    [DhcpOption(DhcpOptionTypeCode.TimeOffset)]
    public class DhcpTimeOffsetOption : IDhcpOption
    {
        internal DhcpTimeOffsetOption(int seconds)
        {
            Offset = TimeSpan.FromSeconds(seconds);
        }

        public DhcpTimeOffsetOption(TimeSpan offset)
        {
            Offset = offset;
        }

        public TimeSpan Offset { get; }
    }
}