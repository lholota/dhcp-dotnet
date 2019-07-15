using System;
using System.Collections.Generic;
using System.Globalization;
using System.Reflection;
using LH.Dhcp.Options;

namespace LH.Dhcp.Serialization.OptionSerialization
{
    internal class DhcpOptionsSerializer
    {
        private readonly DhcpOptionTypeDescriptorsCollection _optionTypeDescriptors;

        public DhcpOptionsSerializer()
        {
            _optionTypeDescriptors = new DhcpOptionTypeDescriptorsCollection();
        }

        public IReadOnlyList<IDhcpOption> DeserializeOptions(DhcpBinaryReader binaryReader)
        {
            // TODO: Use value reader to unify the reading of code+length+value bytes

            var result = new List<IDhcpOption>();

            while (binaryReader.CanRead())
            {
                var optionTypeCode = (DhcpOptionTypeCode)binaryReader.ReadByte();

                if (optionTypeCode == DhcpOptionTypeCode.End)
                {
                    break;
                }

                if (optionTypeCode == DhcpOptionTypeCode.Pad)
                {
                    // Skip Pad option because it does not have length or value
                    continue;
                }

                var descriptor = _optionTypeDescriptors.GetDescriptor(optionTypeCode);

                var optionValueLength = binaryReader.ReadByte();

                if (descriptor == null)
                {
                    // Option is not supported, skip the option length
                    binaryReader.Seek(optionValueLength);

                    continue;
                }

                var optionValueReader = binaryReader.CreateValueReader(optionValueLength);
                var optionValue = GetOptionValue(optionValueReader, descriptor.OptionValueType);

                result.Add(CreateOption(descriptor.OptionType, optionValue));
            }

            return result;
        }

        private static object GetOptionValue(DhcpBinaryValueReader optionValueReader, Type optionType)
        {
            if (!optionValueReader.IsValid(optionType))
            {
                throw new DhcpSerializationException("");
            }

            return optionValueReader.As(optionType);
        }

        private IDhcpOption CreateOption(Type optionType, object optionValue)
        {
            return (IDhcpOption)Activator.CreateInstance(
                optionType,
                BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic,
                null,
                new[] { optionValue },
                CultureInfo.InvariantCulture);
        }
    }
}