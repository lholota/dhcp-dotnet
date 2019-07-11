namespace LH.Dhcp
{
    public enum DhcpMessageType : uint
    {
        DhcpDiscover = 1,
        DhcpOffer = 2,
        DhcpRequest = 3,
        DhcpDecline = 4,
        DhcpAck = 5,
        DhcpNak = 6,
        DhcpRelease = 7,
        DhcpInform = 8
    }
}
