using LH.Dhcp.Serialization.OptionSerialization;
using LH.Dhcp.Serialization.OptionSerialization.OptionValueSerialization;

namespace LH.Dhcp.Options
{
    [DhcpOption(DhcpOptionTypeCode.DefaultIPTTL, typeof(DhcpByteOptionSerializer))]
    public class DhcpDefaultIpTtlOption : IDhcpOption
    {
        public byte Ttl { get; }

        public DhcpDefaultIpTtlOption(byte ttl)
        {
            Ttl = ttl;
        }
    }
}
