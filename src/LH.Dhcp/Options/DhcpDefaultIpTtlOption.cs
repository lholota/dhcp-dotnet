using LH.Dhcp.Serialization.OptionSerialization;

namespace LH.Dhcp.Options
{
    [DhcpOption(DhcpOptionCode.DefaultIPTTL)]
    public class DhcpDefaultIpTtlOption : IDhcpOption
    {
        public DhcpDefaultIpTtlOption(byte ttl)
        {
            Ttl = ttl;
        }

        public byte Ttl { get; }
    }
}
