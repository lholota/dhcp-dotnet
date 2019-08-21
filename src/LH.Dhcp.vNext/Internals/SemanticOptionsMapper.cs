using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using LH.Dhcp.vNext.Options;

namespace LH.Dhcp.vNext.Internals
{
    internal class SemanticOptionsMapper
    {
        private static SemanticOptionsMapper _instance;

        private static readonly object InstanceLock = new object();

        public static SemanticOptionsMapper Instance
        {
            get
            {
                if (_instance == null)
                {
                    lock (InstanceLock)
                    {
                        if (_instance == null)
                        {
                            _instance = new SemanticOptionsMapper();
                        }
                    }
                }

                return _instance;
            }
        }

        private IReadOnlyDictionary<Type, byte> _typeToCodeMapping;

        private SemanticOptionsMapper()
        {
            CreateMappings();
        }

        public byte GetOptionCodeByType(Type type)
        {
            if (!_typeToCodeMapping.TryGetValue(type, out var result))
            {
                throw new KeyNotFoundException($"The option type {type} is not a known DHCP Option.");
            }

            return result;
        }

        private void CreateMappings()
        {
            var optionInterfaceType = typeof(IDhcpOption);

            var types = typeof(SemanticOptionsMapper).Assembly
                .GetTypes()
                .Where(x => x.IsClass && !x.IsAbstract && optionInterfaceType.IsAssignableFrom(x));

            var typeToCodeMapping = new Dictionary<Type, byte>();

            foreach (var type in types)
            {
                var optionCodeAttribute = type.GetCustomAttribute<DhcpOptionCodeAttribute>();

                if (optionCodeAttribute == null)
                {
                    throw new Exception($"The type {type} does not have the mapping attribute.");
                }

                typeToCodeMapping.Add(type, (byte)optionCodeAttribute.OptionCode);
            }

            _typeToCodeMapping = typeToCodeMapping;
        }
    }
}