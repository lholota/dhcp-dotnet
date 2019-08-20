using System;
using LH.Dhcp.Options;

namespace LH.Dhcp.Serialization.OptionSerialization
{
    [AttributeUsage(AttributeTargets.Class)]
    internal class DhcpOptionAttribute : Attribute
    {
        public DhcpOptionCode OptionCode { get; }

        public DhcpOptionAttribute(DhcpOptionCode optionCode)
        {
            OptionCode = optionCode;
        }
    }
}