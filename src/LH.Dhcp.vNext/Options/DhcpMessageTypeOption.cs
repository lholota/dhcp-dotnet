using LH.Dhcp.vNext.Internals;

namespace LH.Dhcp.vNext.Options
{
    public enum DhcpMessageType : byte
    {
        Discover = 1,
        Offer = 2,
        Request = 3,
        Decline = 4,
        Ack = 5,
        NAck = 6,
        Release = 7,
        Inform = 8
    }

    [DhcpOptionCode(DhcpOptionCode.DHCPMessageType)]
    public class DhcpMessageTypeOption : IDhcpOption
    {
        public DhcpMessageTypeOption(DhcpMessageType messageType)
        {
            MessageType = messageType;
        }

        [SemanticOptionsFactoryConstructor]
        internal DhcpMessageTypeOption(BinaryValue binaryValue)
        {
            MessageType = (DhcpMessageType) binaryValue.AsByte();
        }

        public DhcpMessageType MessageType { get; }
    }
}