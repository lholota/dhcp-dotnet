using System;
using System.Reflection;

namespace LH.Dhcp.Serialization.OptionSerialization
{
    internal class DhcpOptionTypeDescriptor
    {
        public Type OptionType { get; }

        public Type OptionValueType { get; }

        public ConstructorInfo Constructor { get; }

        public DhcpOptionTypeDescriptor(Type optionType, Type optionValueType, ConstructorInfo constructor)
        {
            OptionType = optionType;
            OptionValueType = optionValueType;
            Constructor = constructor;
        }
    }
}
