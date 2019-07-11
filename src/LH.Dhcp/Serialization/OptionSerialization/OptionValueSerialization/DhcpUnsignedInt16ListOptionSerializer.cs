namespace LH.Dhcp.Serialization.OptionSerialization.OptionValueSerialization
{
    internal class DhcpUnsignedInt16ListOptionSerializer : IDhcpOptionValueSerializer
    {
        public object Deserialize(DhcpBinaryReader reader, byte valueLength)
        {
            if (valueLength % 2 != 0)
            {
                throw new DhcpSerializationException("The option length is invalid. List UnsignedInt16 must be divisible by 2.");
            }

            var itemCount = valueLength / 2;
            var result = new ushort[itemCount];

            for (var i = 0; i < itemCount; i++)
            {
                result[i] = reader.ReadUnsignedInt16();
            }

            return result;
        }
    }
}