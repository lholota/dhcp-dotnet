using System;

namespace LH.Dhcp.Serialization.OptionSerialization.OptionValueSerialization
{
    internal class DhcpIpAddressOptionSerializer : IDhcpOptionValueSerializer
    {
        public object Deserialize(DhcpBinaryReader reader, byte valueLength)
        {
            if (valueLength != 4) // IPv4 address length
            {
                throw new ArgumentException("The option length is invalid. IP address must be exactly 4 bytes long.");
            }

            return reader.ReadIpAddress();
        }
    }
}