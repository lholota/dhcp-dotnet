using System;
using LH.Dhcp.Options;

namespace LH.Dhcp.Serialization.OptionSerialization
{
    [AttributeUsage(AttributeTargets.Class)]
    internal class DhcpOptionAttribute : Attribute
    {
        public DhcpOptionTypeCode OptionTypeCode { get; }

        public Type SerializerType { get; }

        public DhcpOptionAttribute(DhcpOptionTypeCode optionTypeCode, Type serializerType)
        {
            OptionTypeCode = optionTypeCode;
            SerializerType = serializerType;
        }
    }
}