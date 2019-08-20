using System;

namespace LH.Dhcp.vNext.Internals
{
    [AttributeUsage(AttributeTargets.Class)]
    internal class DhcpOptionCodeAttribute : Attribute
    {
        public DhcpOptionCode OptionCode { get; }

        public DhcpOptionCodeAttribute(DhcpOptionCode optionCode)
        {
            OptionCode = optionCode;
        }
    }
}