using System;

namespace LH.Dhcp.vNext.Options
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