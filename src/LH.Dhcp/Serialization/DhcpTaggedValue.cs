namespace LH.Dhcp.Serialization
{
    internal class DhcpTaggedValue
    {
        public DhcpTaggedValue(byte tag, DhcpBinaryValue value)
        {
            Tag = tag;
            Value = value;
        }

        public byte Tag { get; }

        public DhcpBinaryValue Value { get; }
    }
}