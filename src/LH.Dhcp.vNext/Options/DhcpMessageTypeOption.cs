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

    [DhcpOption(DhcpOptionCode.DHCPMessageType)]
    public class DhcpMessageTypeOption : IDhcpOption
    {
        public DhcpMessageTypeOption(DhcpMessageType messageType)
        {
            MessageType = messageType;
        }

        // [CreateOptionConstructor]
        internal DhcpMessageTypeOption(byte value)
        {
            MessageType = (DhcpMessageType) value;
        }

        public DhcpMessageType MessageType { get; }
    }
}