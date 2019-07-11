using System.Collections.Generic;
using System.Net;

namespace LH.Dhcp.Serialization.OptionSerialization.OptionValueSerialization
{
    internal class DhcpIpAddressListOptionSerializer : IDhcpOptionValueSerializer
    {
        public object Deserialize(DhcpBinaryReader reader, byte valueLength)
        {
            if (valueLength % 4 != 0)
            {
                throw new DhcpSerializationException("The option length is invalid, it must divisible by 4.");
            }

            var ipCount = valueLength / 4;
            var result = new IPAddress[ipCount];

            for (int i = 0; i < ipCount; i++)
            {
                result[i] = reader.ReadIpAddress();
            }

            return result;
        }
    }
}
