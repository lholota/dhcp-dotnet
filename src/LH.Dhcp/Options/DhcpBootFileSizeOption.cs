using LH.Dhcp.Serialization.OptionSerialization;

namespace LH.Dhcp.Options
{
    [DhcpOption(DhcpOptionCode.BootFileSize)]
    public class DhcpBootFileSizeOption : IDhcpOption
    {
        public DhcpBootFileSizeOption(ushort bootFileSize)
        {
            BootFileSize = bootFileSize;
        }

        public ushort BootFileSize { get; }
    }
}