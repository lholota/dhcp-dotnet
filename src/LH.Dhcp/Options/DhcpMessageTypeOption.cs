using LH.Dhcp.Serialization.OptionSerialization;

namespace LH.Dhcp.Options
{
    [DhcpOption(DhcpOptionCode.DHCPMsgType)]
    public class DhcpMessageTypeOption : IDhcpOption
    {
        public DhcpMessageTypeOption(DhcpMessageType messageType)
        {
            MessageType = messageType;
        }

        [CreateOptionConstructor]
        internal DhcpMessageTypeOption(byte value)
        {
            MessageType = (DhcpMessageType) value;
        }

        public DhcpMessageType MessageType { get; }
    }
}