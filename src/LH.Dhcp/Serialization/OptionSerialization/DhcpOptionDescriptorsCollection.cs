using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using LH.Dhcp.Options;
using LH.Dhcp.Serialization.OptionSerialization.OptionValueSerialization;

namespace LH.Dhcp.Serialization.OptionSerialization
{
    internal class DhcpOptionDescriptorsCollection
    {
        private static readonly IReadOnlyList<IDhcpOptionValueSerializer> ValueSerializers = new List<IDhcpOptionValueSerializer>
        {
            new DhcpIpAddressOptionSerializer()
        };

        private readonly IDictionary<DhcpOptionTypeCode, DhcpOptionDescriptor> _enumToTypeMapping;

        public DhcpOptionDescriptorsCollection()
        {
            var optionTypes = GetType().Assembly
                .GetTypes()
                .Where(IsDhcpOptionType);

            _enumToTypeMapping = GetEnumToDescriptorMapping(optionTypes);
        }

        public DhcpOptionDescriptor GetDescriptor(DhcpOptionTypeCode optionTypeCode)
        {
            if (_enumToTypeMapping.TryGetValue(optionTypeCode, out var descriptor))
            {
                return descriptor;
            }

            return null;
        }

        private Dictionary<DhcpOptionTypeCode, DhcpOptionDescriptor> GetEnumToDescriptorMapping(IEnumerable<Type> optionTypes)
        {
            var mapping = new Dictionary<DhcpOptionTypeCode, DhcpOptionDescriptor>();

            foreach (var optionType in optionTypes)
            {
                var dhcpOptionAttribute = optionType.GetCustomAttribute<DhcpOptionAttribute>();

                var optionValueSerializer = GetOptionValueSerializer(dhcpOptionAttribute.SerializerType);

                var descriptor = new DhcpOptionDescriptor(optionType, optionValueSerializer);

                mapping.Add(dhcpOptionAttribute.OptionTypeCode, descriptor);
            }

            return mapping;
        }

        private IDhcpOptionValueSerializer GetOptionValueSerializer(Type serializerType)
        {
            var serializer = ValueSerializers.SingleOrDefault(x => x.GetType() == serializerType);

            if (serializer == null)
            {
                throw new NotSupportedException($"DhcpOptions with value type {serializerType} are not supported.");
            }

            return serializer;
        }

        private bool IsDhcpOptionType(Type type)
        {
            return typeof(IDhcpOption).IsAssignableFrom(type)
                   && type.GetCustomAttribute<DhcpOptionAttribute>() != null;
        }
    }
}