namespace LH.Dhcp.Serialization.OptionSerialization.OptionValueSerialization
{
    internal class DhcpByteOptionSerializer : IDhcpOptionValueSerializer
    {
        public object Deserialize(DhcpBinaryReader reader, byte valueLength)
        {
            if (valueLength != 1)
            {
                throw new DhcpSerializationException("The option length is invalid. Byte must be exactly 1 byte long.");
            }

            return reader.ReadByte();
        }
    }
}