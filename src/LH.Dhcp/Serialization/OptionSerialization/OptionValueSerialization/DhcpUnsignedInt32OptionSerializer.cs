namespace LH.Dhcp.Serialization.OptionSerialization.OptionValueSerialization
{
    internal class DhcpUnsignedInt32OptionSerializer : IDhcpOptionValueSerializer
    {
        public object Deserialize(DhcpBinaryReader reader, byte valueLength)
        {
            if (valueLength != 4)
            {
                throw new DhcpSerializationException("The option length is invalid. UnsignedInt16 must be exactly 2 bytes long.");
            }

            return reader.ReadUnsignedInt32();
        }
    }
}