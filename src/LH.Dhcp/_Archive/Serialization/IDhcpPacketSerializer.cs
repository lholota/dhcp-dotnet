namespace LH.Dhcp.Serialization
{
    public interface IDhcpPacketSerializer
    {
        byte[] Serialize(DhcpPacket packet);

        DhcpPacket Deserialize(byte[] bytes);
    }
}