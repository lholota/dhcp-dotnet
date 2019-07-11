using System;

namespace LH.Dhcp.Serialization
{
    public class DhcpSerializationException : Exception
    {
        public DhcpSerializationException(string message, Exception inner = null)
            : base(message, inner)
        {
        }
    }
}
