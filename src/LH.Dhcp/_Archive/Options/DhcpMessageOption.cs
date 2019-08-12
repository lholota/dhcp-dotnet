using LH.Dhcp.Serialization.OptionSerialization;

namespace LH.Dhcp.Options
{
    [DhcpOption(DhcpOptionTypeCode.DHCPMessage)]
    public class DhcpMessageOption : IDhcpOption
    {
        public DhcpMessageOption(string message)
        {
            Message = message;
        }

        public string Message { get; }
    }
}