using LH.Dhcp.Serialization.OptionSerialization;
using LH.Dhcp.Serialization.OptionSerialization.OptionValueSerialization;

namespace LH.Dhcp.Options
{
    [DhcpOption(DhcpOptionTypeCode.BootFileSize, typeof(DhcpUnsignedInt16OptionSerializer))]
    public class DhcpBootFileSizeOption : IDhcpOption
    {
        public int BootFileSize { get; }

        public DhcpBootFileSizeOption(int bootFileSize)
        {
            BootFileSize = bootFileSize;
        }
    }
}