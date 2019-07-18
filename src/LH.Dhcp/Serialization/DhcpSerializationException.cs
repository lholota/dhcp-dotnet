using System;
using System.Runtime.Serialization;

namespace LH.Dhcp.Serialization
{
    [Serializable]
    public class DhcpSerializationException : Exception
    {
        public DhcpSerializationException(string message, Exception inner = null)
            : base(message, inner)
        {
        }

        protected DhcpSerializationException(SerializationInfo info, StreamingContext context) 
            : base(info, context)
        {
        }
    }
}