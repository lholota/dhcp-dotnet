using System;
using LH.Dhcp.Serialization.OptionSerialization;
using LH.Dhcp.Serialization.OptionSerialization.OptionValueSerialization;

namespace LH.Dhcp.Options
{
    [DhcpOption(DhcpOptionTypeCode.TimeOffset, typeof(DhcpInt32OptionSerializer))]
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