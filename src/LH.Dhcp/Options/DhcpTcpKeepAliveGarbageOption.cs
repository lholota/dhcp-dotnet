using LH.Dhcp.Serialization.OptionSerialization;
using LH.Dhcp.Serialization.OptionSerialization.OptionValueSerialization;

namespace LH.Dhcp.Options
{
    [DhcpOption(DhcpOptionTypeCode.KeepaliveData, typeof(DhcpBooleanOptionSerializer))]
    public class DhcpTcpKeepAliveGarbageOption : IDhcpOption
    {
        public DhcpTcpKeepAliveGarbageOption(bool keepAliveGarbage)
        {
            KeepAliveGarbage = keepAliveGarbage;
        }

        public bool KeepAliveGarbage { get; }
    }
}