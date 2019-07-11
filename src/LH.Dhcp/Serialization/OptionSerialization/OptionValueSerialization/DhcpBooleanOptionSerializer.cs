namespace LH.Dhcp.Serialization.OptionSerialization.OptionValueSerialization
{
    internal class DhcpBooleanOptionSerializer : IDhcpOptionValueSerializer
    {
        public object Deserialize(DhcpBinaryReader reader, byte valueLength)
        {
            if (valueLength != 1)
            {
                throw new DhcpSerializationException("The option length is invalid. Boolean must be exactly 1 byte long.");
            }

            var value = reader.ReadByte();

            return value == 1;
        }
    }
}
