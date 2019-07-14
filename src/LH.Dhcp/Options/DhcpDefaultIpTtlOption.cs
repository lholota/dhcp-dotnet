using LH.Dhcp.Serialization.OptionSerialization;

namespace LH.Dhcp.Options
{
    [DhcpOption(DhcpOptionTypeCode.DefaultIPTTL)]
    public class DhcpDefaultIpTtlOption : IDhcpOption
    {
        public DhcpDefaultIpTtlOption(byte ttl)
        {
            Ttl = ttl;
        }

        public byte Ttl { get; }
    }
}
