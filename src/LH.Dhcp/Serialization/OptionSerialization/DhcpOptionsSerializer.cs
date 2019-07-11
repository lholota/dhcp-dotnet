using System;
using System.Collections.Generic;
using System.Globalization;
using System.Reflection;
using LH.Dhcp.Options;

namespace LH.Dhcp.Serialization.OptionSerialization
{
    internal class DhcpOptionsSerializer
    {
        private readonly DhcpOptionDescriptorsCollection _optionDescriptorsCollection;

        public DhcpOptionsSerializer()
        {
            _optionDescriptorsCollection = new DhcpOptionDescriptorsCollection();
        }

        public IReadOnlyList<IDhcpOption> DeserializeOptions(DhcpBinaryReader reader)
        {
            var result = new List<IDhcpOption>();

            while (reader.CanRead())
            {
                var optionTypeCode = (DhcpOptionTypeCode)reader.ReadByte();

                if (optionTypeCode == DhcpOptionTypeCode.End)
                {
                    break;
                }

                if (optionTypeCode == DhcpOptionTypeCode.Pad)
                {
                    // Skip Pad option because it does not have length or value
                    continue;
                }

                var descriptor = _optionDescriptorsCollection.GetDescriptor(optionTypeCode);

                var optionValueLength = reader.ReadByte();

                if (descriptor == null)
                {
                    // Option is not supported, skip the option length
                    reader.Seek(optionValueLength);

                    continue;
                }

                var optionValue = descriptor.ValueSerializer.Deserialize(reader, optionValueLength);

                result.Add(CreateOption(descriptor, optionValue));
            }

            return result;
        }

        private IDhcpOption CreateOption(DhcpOptionDescriptor descriptor, object value)
        {
            return (IDhcpOption)Activator.CreateInstance(
                descriptor.OptionType,
                BindingFlags.CreateInstance,
                null,
                new[] { value },
                CultureInfo.InvariantCulture);
        }
    }
}