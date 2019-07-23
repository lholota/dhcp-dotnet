namespace LH.Dhcp
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
}
