namespace LH.Dhcp.Serialization.OptionSerialization.OptionValueSerialization
{
    internal interface IDhcpOptionValueSerializer
    {
        object Deserialize(DhcpBinaryReader reader, byte valueLength);
    }
}