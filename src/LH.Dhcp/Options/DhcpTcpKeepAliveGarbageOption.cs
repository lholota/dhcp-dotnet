using LH.Dhcp.Serialization.OptionSerialization;

namespace LH.Dhcp.Options
{
    [DhcpOption(DhcpOptionTypeCode.KeepaliveData)]
    public class DhcpTcpKeepAliveGarbageOption : IDhcpOption
    {
        public DhcpTcpKeepAliveGarbageOption(bool keepAliveGarbage)
        {
            KeepAliveGarbage = keepAliveGarbage;
        }

        public bool KeepAliveGarbage { get; }
    }
}