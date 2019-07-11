using System;
using System.Collections.Generic;
using System.Net;

namespace LH.Dhcp.Serialization.OptionSerialization.OptionValueSerialization
{
    internal class DhcpIpAddressPairOptionSerializer : IDhcpOptionValueSerializer
    {
        public object Deserialize(DhcpBinaryReader reader, byte valueLength)
        {
            if (valueLength == 0 || valueLength % 8 != 0)
            {
                throw new DhcpSerializationException("The option length is invalid, it must divisible by 8 (2*4 bytes for IPv4 address).");
            }

            var result = new List<Tuple<IPAddress, IPAddress>>();
            var pairsCount = valueLength / 8;

            for (var i = 0; i < pairsCount; i++)
            {
                var ip1 = reader.ReadIpAddress();
                var ip2 = reader.ReadIpAddress();

                var tupple = new Tuple<IPAddress, IPAddress>(ip1, ip2);

                result.Add(tupple);
            }

            return result;
        }
    }
}