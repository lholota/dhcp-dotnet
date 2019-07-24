using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using LH.Dhcp.Options;

namespace LH.Dhcp.Serialization.OptionSerialization
{
    internal class DhcpOptionTypeCatalog
    {
        private readonly IDictionary<DhcpOptionTypeCode, DhcpOptionType> _enumToTypeMapping;

        public DhcpOptionTypeCatalog()
        {
            var optionTypes = GetType().Assembly
                .GetTypes()
                .Where(IsDhcpOptionType);

            _enumToTypeMapping = GetEnumToOptionTypeMapping(optionTypes);
        }

        public DhcpOptionType GetOptionType(DhcpOptionTypeCode optionTypeCode)
        {
            if (_enumToTypeMapping.TryGetValue(optionTypeCode, out var descriptor))
            {
                return descriptor;
            }

            return null;
        }

        private Dictionary<DhcpOptionTypeCode, DhcpOptionType> GetEnumToOptionTypeMapping(IEnumerable<Type> optionTypes)
        {
            var mapping = new Dictionary<DhcpOptionTypeCode, DhcpOptionType>();

            foreach (var optionType in optionTypes)
            {
                var dhcpOptionAttribute = optionType.GetCustomAttribute<DhcpOptionAttribute>();

                var descriptor = new DhcpOptionType(optionType);

                mapping.Add(dhcpOptionAttribute.OptionTypeCode, descriptor);
            }

            return mapping;
        }

        private bool IsDhcpOptionType(Type type)
        {
            return typeof(IDhcpOption).IsAssignableFrom(type)
                   && type.GetCustomAttribute<DhcpOptionAttribute>() != null;
        }
    }

    [AttributeUsage(AttributeTargets.Constructor)]
    internal class CreateOptionConstructorAttribute : Attribute
    {
    }
}