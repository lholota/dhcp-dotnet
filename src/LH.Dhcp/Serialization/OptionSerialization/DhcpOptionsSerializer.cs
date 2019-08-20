using System.Collections.Generic;

namespace LH.Dhcp.Serialization.OptionSerialization
{
    internal class DhcpOptionsSerializer
    {
        public IEnumerable<KeyValuePair<byte, IBinaryValue>> DeserializeOptions(DhcpBinaryReader binaryReader)
        {
            return binaryReader.ReadValueToEnd().AsTaggedValueCollection();
        }
    }
}