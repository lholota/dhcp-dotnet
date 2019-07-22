using System;
using LH.Dhcp.Serialization.OptionSerialization;

namespace LH.Dhcp.Options
{
    [DhcpOption(DhcpOptionTypeCode.DHCPMaxMsgSize)]
    public class DhcpMaxMessageSizeOption : IDhcpOption
    {
        public DhcpMaxMessageSizeOption(ushort maxSize)
        {
            if (maxSize < 576)
            {
                throw new ArgumentOutOfRangeException(nameof(maxSize), "The DHCP Maximum Message size must be at least 576.");
            }

            MaxSize = maxSize;
        }

        public ushort MaxSize { get; }
    }
}
