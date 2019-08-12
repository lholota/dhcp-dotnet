using System;
using LH.Dhcp.Options;

namespace LH.Dhcp.Serialization.OptionSerialization
{
    [AttributeUsage(AttributeTargets.Class)]
    internal class DhcpOptionAttribute : Attribute
    {
        public DhcpOptionTypeCode OptionTypeCode { get; }

        public DhcpOptionAttribute(DhcpOptionTypeCode optionTypeCode)
        {
            OptionTypeCode = optionTypeCode;
        }
    }
}