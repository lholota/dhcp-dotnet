namespace LH.Dhcp.Serialization.OptionSerialization.OptionValueSerialization
{
    internal class DhcpUnsignedInt16OptionSerializer : IDhcpOptionValueSerializer
    {
        public object Deserialize(DhcpBinaryReader reader, byte valueLength)
        {
            if (valueLength != 2)
            {
                throw new DhcpSerializationException("The option length is invalid. UnsignedInt16 must be exactly 2 bytes long.");
            }

            return reader.ReadUnsignedInt16();
        }
    }
}
