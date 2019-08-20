using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace LH.Dhcp.vNext.Options
{
    internal static class SemanticOptionsMapper
    {
        private static readonly object MappingsLock = new object();

        private static IReadOnlyDictionary<Type, byte> _typeToCodeMapping;

        public static byte GetOptionCodeByType(Type type)
        {
            EnsureMappings();

            if (!_typeToCodeMapping.TryGetValue(type, out var result))
            {
                throw new KeyNotFoundException($"The option type {type} is not a known DHCP Option.");
            }

            return result;
        }

        private static void EnsureMappings()
        {
            if (_typeToCodeMapping != null)
            {
                return;
            }

            lock (MappingsLock)
            {
                if (_typeToCodeMapping == null)
                {
                    var optionInterfaceType = typeof(IDhcpOption);

                    var types = typeof(SemanticOptionsMapper).Assembly
                        .GetTypes()
                        .Where(x => x.IsClass && !x.IsAbstract && optionInterfaceType.IsAssignableFrom(x));

                    var typeToCodeMapping = new Dictionary<Type, byte>();

                    foreach (var type in types)
                    {
                        var optionCodeAttribute = type.GetCustomAttribute<DhcpOptionAttribute>();

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
    }
}