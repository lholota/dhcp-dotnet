using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using LH.Dhcp.Options;

namespace LH.Dhcp.Serialization.OptionSerialization
{
    internal class DhcpOptionTypeDescriptorsCollection
    {
        private readonly IDictionary<DhcpOptionTypeCode, DhcpOptionTypeDescriptor> _enumToTypeMapping;

        public DhcpOptionTypeDescriptorsCollection()
        {
            var optionTypes = GetType().Assembly
                .GetTypes()
                .Where(IsDhcpOptionType);

            _enumToTypeMapping = GetEnumToDescriptorMapping(optionTypes);
        }

        public DhcpOptionTypeDescriptor GetDescriptor(DhcpOptionTypeCode optionTypeCode)
        {
            if (_enumToTypeMapping.TryGetValue(optionTypeCode, out var descriptor))
            {
                return descriptor;
            }

            return null;
        }

        private Dictionary<DhcpOptionTypeCode, DhcpOptionTypeDescriptor> GetEnumToDescriptorMapping(IEnumerable<Type> optionTypes)
        {
            var mapping = new Dictionary<DhcpOptionTypeCode, DhcpOptionTypeDescriptor>();

            foreach (var optionType in optionTypes)
            {
                var dhcpOptionAttribute = optionType.GetCustomAttribute<DhcpOptionAttribute>();

                var optionTypeCtor = GetOptionConstructor(optionType);
                var optionValueType = optionTypeCtor.GetParameters()[0].ParameterType;

                var descriptor = new DhcpOptionTypeDescriptor(optionType, optionValueType, optionTypeCtor);

                mapping.Add(dhcpOptionAttribute.OptionTypeCode, descriptor);
            }

            return mapping;
        }

        private ConstructorInfo GetOptionConstructor(Type optionType)
        {
            var matchingCtors = optionType
                .GetConstructors(BindingFlags.Instance | BindingFlags.NonPublic | BindingFlags.Public)
                .Where(x => x.GetParameters().Length == 1)
                .ToArray();

            if (matchingCtors.Length == 1)
            {
                return matchingCtors[0];
            }

            var ctorsWithAttribute = matchingCtors
                .Where(x => x.GetCustomAttribute<CreateOptionConstructorAttribute>() != null)
                .ToArray();

            if (ctorsWithAttribute.Length != 1)
            {
                throw new Exception($"The option type {optionType} does not have a constructor to create option during deserialization.");
            }

            return ctorsWithAttribute[0];
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