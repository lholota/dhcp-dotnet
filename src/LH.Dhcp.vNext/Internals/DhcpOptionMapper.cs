using System;
using System.Collections.Generic;

namespace LH.Dhcp.vNext.Internals
{
    internal static class DhcpOptionMapper
    {
        private static Lazy<DhcpOptionMappings> _typeToCodeMappings = new Lazy<DhcpOptionMappings>(GetMappings);

        public static byte GetOptionCode(Type optionType)
        {
            throw new NotImplementedException();
        }

        public static Type GetOptionType(byte optionCode)
        {
            throw new NotImplementedException();
        }

        private static DhcpOptionMappings GetMappings()
        {
            throw new NotImplementedException();
        }

        private class DhcpOptionMappings
        {
            public DhcpOptionMappings(
                IReadOnlyDictionary<byte, Type> codeToTypeMappings,
                IReadOnlyDictionary<Type, byte> typeToCodeMappings)
            {
                CodeToTypeMappings = codeToTypeMappings;
                TypeToCodeMappings = typeToCodeMappings;
            }

            public IReadOnlyDictionary<Type, byte> TypeToCodeMappings { get; }

            public IReadOnlyDictionary<byte, Type> CodeToTypeMappings { get; }
        }
    }
}