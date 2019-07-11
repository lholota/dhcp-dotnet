namespace LH.Dhcp.Serialization.OptionSerialization.OptionValueSerialization
{
    internal class DhcpInt32OptionSerializer : IDhcpOptionValueSerializer
    {
        public object Deserialize(DhcpBinaryReader reader, byte valueLength)
        {
            if (valueLength != 4)
            {
                throw new DhcpSerializationException("The option length is invalid. Int32 must be exactly 4 bytes long.");
            }

            return reader.ReadInt32();
        }
    }
}
