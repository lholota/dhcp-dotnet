using LH.Dhcp.Serialization.OptionSerialization;

namespace LH.Dhcp.Options
{
    [DhcpOption(DhcpOptionCode.DefaultTCPTTL)]
    public class DhcpDefaultTcpTtlOption : IDhcpOption
    {
        public DhcpDefaultTcpTtlOption(byte ttl)
        {
            Ttl = ttl;
        }

        public byte Ttl { get; }
    }
}