using LH.Dhcp.Serialization.OptionSerialization;
using LH.Dhcp.Serialization.OptionSerialization.OptionValueSerialization;

namespace LH.Dhcp.Options
{
    [DhcpOption(DhcpOptionTypeCode.DefaultTCPTTL, typeof(DhcpByteOptionSerializer))]
    public class DhcpDefaultTcpTtlOption : IDhcpOption
    {
        public DhcpDefaultTcpTtlOption(byte ttl)
        {
            Ttl = ttl;
        }

        public byte Ttl { get; }
    }
}