using System;
using LH.Dhcp.Serialization.OptionSerialization.OptionValueSerialization;

namespace LH.Dhcp.Serialization.OptionSerialization
{
    internal class DhcpOptionDescriptor
    {
        public IDhcpOptionValueSerializer ValueSerializer { get; }

        public Type OptionType { get; }

        public DhcpOptionDescriptor(Type optionType, IDhcpOptionValueSerializer valueSerializer)
        {
            ValueSerializer = valueSerializer;
            OptionType = optionType;
        }
    }
}